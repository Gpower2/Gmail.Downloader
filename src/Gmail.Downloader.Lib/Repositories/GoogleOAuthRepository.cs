using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Gmail.Downloader.Lib.Extensions;
using Gmail.Downloader.Lib.Repositories.Abstractions;
using Gmail.Downloader.Lib.Services;
using Microsoft.Extensions.Logging;

namespace Gmail.Downloader.Lib.Repositories
{
    public class GoogleOAuthRepository : IGoogleOAuthRepository
    {
        const string AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        const string responseString = "<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>";
        const string codeChallengeMethod = "S256";

        const string tokenRequestUri = "https://www.googleapis.com/oauth2/v4/token";

        private static readonly string gmailReadonlyScope = Uri.EscapeDataString("https://www.googleapis.com/auth/gmail.readonly");

        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(tokenRequestUri)
        };

        private readonly ILogger<GoogleOAuthRepository> _logger;

        public GoogleOAuthRepository(ILogger<GoogleOAuthRepository> logger)
        {
            ArgumentNullException.ThrowIfNull(_logger = logger);
        }

        public async Task<string> DoOAuthAsync(string clientId, string clientSecret)
        {
            // Generates state and PKCE values.
            string state = Base64Service.GenerateRandomDataBase64url(32);
            string codeVerifier = Base64Service.GenerateRandomDataBase64url(32);
            string codeChallenge = Base64Service.EncodeBase64UrlWithNoPadding(CryptographyExtensions.GetSha256BytesFromAsciiText(codeVerifier));

            // Creates an HttpListener to listen for requests on
            // a redirect URI using an available port on the loopback address            
            HttpListenerService.TryBindListenerOnFreePort(out HttpListener http, out string redirectUri, out int port);

            _logger.LogInformation("HTTP server started at {HttpServerEndpoint}...", redirectUri);

            // Creates the OAuth 2.0 authorization request.

            Dictionary<string, string> queryValues = new Dictionary<string, string>();

            // Determines whether the Google OAuth 2.0 endpoint returns an authorization code.
            // Set the parameter value to code for web server applications.
            queryValues.Add("response_type", "code");

            // A space-delimited list of scopes that identify the resources that your application could access on the user's behalf.
            // These values inform the consent screen that Google displays to the user.
            queryValues.Add("scope", $"openid%20profile {gmailReadonlyScope}");

            // Indicates whether your application can refresh access tokens when the user is not present at the browser.
            // Valid parameter values are online, which is the default value, and offline.
            queryValues.Add("access_type", "offline");

            // Enables applications to use incremental authorization to request access to additional scopes in context.
            // If you set this parameter's value to true and the authorization request is granted, then the new access token will also cover
            // any scopes to which the user previously granted the application access
            queryValues.Add("include_granted_scopes", "true");

            queryValues.Add("redirect_uri", Uri.EscapeDataString(redirectUri));

            queryValues.Add("client_id", clientId);

            queryValues.Add("state", state);
            queryValues.Add("code_challenge", codeChallenge);
            queryValues.Add("code_challenge_method", codeChallengeMethod);

            string queryString = string.Join("&", queryValues.Select(kvp => $"{kvp.Key}={kvp.Value}"));

            string authorizationRequest = $"{AuthorizationEndpoint}?{queryString}";

            // Opens request in the default browser.
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = authorizationRequest,
                UseShellExecute = true
            };
            Process.Start(psi);

            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Sends an HTTP response to the browser.
            using var response = context.Response;

            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            await responseOutput.WriteAsync(buffer, 0, buffer.Length);
            responseOutput.Close();
            http.Stop();

            _logger.LogInformation("HTTP server stopped...");

            // Checks for errors.
            string error = context.Request.QueryString.Get("error");
            if (error is object)
            {
                _logger.LogError("OAuth authorization error: {Error}.", error);
                throw new Exception();
            }
            if (context.Request.QueryString.Get("code") is null
                || context.Request.QueryString.Get("state") is null)
            {
                _logger.LogError("Malformed authorization response. {QueryString}", context.Request.QueryString);
                throw new Exception();
            }

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var incomingState = context.Request.QueryString.Get("state");

            // Compares the receieved state to the expected value, to ensure that
            // this app made the request which resulted in authorization.
            if (incomingState != state)
            {
                _logger.LogError($"Received request with invalid state ({incomingState})");
                throw new Exception();
            }
            _logger.LogInformation($"Authorization code: {code}");

            // Starts the code exchange at the Token Endpoint.
            return await ExchangeCodeForTokensAsync(code, codeVerifier, redirectUri, clientId, clientSecret);
        }

        public async Task<string> ExchangeCodeForTokensAsync(string code, string codeVerifier, string redirectUri, string clientId, string clientSecret)
        {
            _logger.LogInformation("Exchanging code for tokens...");

            // builds the  request
            string tokenRequestBody = string.Format(
                "code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}&client_secret={4}&scope=&grant_type=authorization_code",
                code,
                Uri.EscapeDataString(redirectUri),
                clientId,
                codeVerifier,
                clientSecret
            );

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;

            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            httpRequestMessage.Content = new StringContent(tokenRequestBody, new MediaTypeHeaderValue("application/x-www-form-urlencoded"));

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            string responseText = await response.Content.ReadAsStringAsync();

            // converts to dictionary
            Dictionary<string, object> tokenEndpointDecoded = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(responseText);
            string accessToken = tokenEndpointDecoded["access_token"].ToString();

            return accessToken;
        }
    }
}
