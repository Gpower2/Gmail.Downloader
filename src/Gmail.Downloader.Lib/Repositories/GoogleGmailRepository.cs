using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Gmail.Downloader.Lib.Constants;
using Gmail.Downloader.Lib.Repositories.Abstractions;
using Microsoft.Extensions.Logging;

namespace Gmail.Downloader.Lib.Repositories
{
    public class GoogleGmailRepository : IGoogleGmailRepository
    {
        const string serviceEndpoint = "https://gmail.googleapis.com";

        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(serviceEndpoint)
        };

        private readonly ILogger<GoogleGmailRepository> _logger;

        public GoogleGmailRepository(ILogger<GoogleGmailRepository> logger)
        {
            ArgumentNullException.ThrowIfNull(_logger = logger);
        }

        public async Task<string> GetCurrentUserProfileAsync(string accessToken)
        {
            // "gmail/v1/users/{userId}/profile"
            // The special value `me` can be used to indicate the authenticated user
            const string path = "gmail/v1/users/me/profile";

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;

            httpRequestMessage.RequestUri = new Uri(serviceEndpoint + "/" + path);

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCurrentUserLabelsAsync(string accessToken)
        {
            // "gmail/v1/users/{userId}/labels"
            // The special value `me` can be used to indicate the authenticated user
            const string path = "gmail/v1/users/me/labels";

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;

            httpRequestMessage.RequestUri = new Uri(serviceEndpoint + "/" + path);

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCurrentUserLabelAsync(string accessToken, string labelId)
        {
            // "gmail/v1/users/{userId}/labels/{id}"
            // The special value `me` can be used to indicate the authenticated user
            const string path = "gmail/v1/users/me/labels/{id}";

            while (true)
            {
                using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Method = HttpMethod.Get;

                httpRequestMessage.RequestUri = new Uri(serviceEndpoint + "/" + path.Replace("{id}", labelId));

                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

                using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

                _logger.LogDebug("Doing a request");

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    // If we get Too Many Requests, wait for 1 second before retrying again
                    _logger.LogWarning("Got Too Many Requests, waiting for 1 sec...");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    continue;
                }
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> GetCurrentUserMessagesAsync(string accessToken, string query, List<string> labels, string pageToken)
        {
            // "gmail/v1/users/{userId}/messages"
            // The special value `me` can be used to indicate the authenticated user
            const string path = "gmail/v1/users/me/messages";

            Dictionary<string, string> queryValues = new Dictionary<string, string>();

            // Maximum number of messages to return. This field defaults to 100. The maximum allowed value for this field is 500.
            queryValues.Add("maxResults", "500");

            // Page token to retrieve a specific page of results in the list.
            if (!string.IsNullOrWhiteSpace(pageToken))
            {
                queryValues.Add("pageToken", pageToken);
            }

            // Only return messages matching the specified query. Supports the same query format as the Gmail search box.
            // For example, "from:someuser@example.com rfc822msgid:<somemsgid@example.com> is:unread".
            // Parameter cannot be used when accessing the api using the gmail.metadata scope.
            if (!string.IsNullOrWhiteSpace(query))
            {
                queryValues.Add("q", query);
            }

            // Only return messages with labels that match all of the specified label IDs.
            // Messages in a thread might have labels that other messages in the same thread don't have.
            if (labels != null && labels.Any())
            {
                queryValues.Add("labelIds", labels[0]);
            }

            // Include messages from SPAM and TRASH in the results.
            queryValues.Add("includeSpamTrash", "true");

            string queryString = string.Join("&", queryValues.Select(kvp => $"{kvp.Key}={kvp.Value}"));

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;

            httpRequestMessage.RequestUri = new Uri(serviceEndpoint + "/" + path + "?" + queryString);

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCurrentUserMessageAsync(string accessToken, string messageId, GoogleGmailFormat.MessageFormat messageFormat)
        {
            // "gmail/v1/users/{userId}/messages/{id}"
            // The special value `me` can be used to indicate the authenticated user
            const string path = "gmail/v1/users/me/messages/{id}";

            Dictionary<string, string> queryValues = new Dictionary<string, string>();

            // The format to return the message in.
            queryValues.Add("format", messageFormat.GetGoogleFormat());

            // When given and format is METADATA, only include headers specified.
            //queryValues.Add("metadataHeaders", "500");

            string queryString = string.Join("&", queryValues.Select(kvp => $"{kvp.Key}={kvp.Value}"));

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;

            httpRequestMessage.RequestUri = new Uri(serviceEndpoint + "/" + path.Replace("{id}", messageId) + "?" + queryString);

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCurrentUserMessageAttachmentAsync(string accessToken, string messageId, string attachmentId)
        {
            // "gmail/v1/users/{userId}/messages/{messageId}/attachments/{id}"
            // The special value `me` can be used to indicate the authenticated user
            const string path = "gmail/v1/users/me/messages/{messageId}/attachments/{id}";

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;

            httpRequestMessage.RequestUri = new Uri(serviceEndpoint + "/" + path.Replace("{messageId}", messageId).Replace("{id}", attachmentId));

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
