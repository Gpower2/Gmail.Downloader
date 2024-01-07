﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Gmail.Downloader.Lib.Services
{
    public class GoogleUserService
    {
        const string userinfoRequestUri = "https://www.googleapis.com/oauth2/v3/userinfo";

        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(userinfoRequestUri)
        };

        private readonly ILogger<GoogleUserService> _logger;

        public GoogleUserService(ILogger<GoogleUserService> logger)
        {
            ArgumentNullException.ThrowIfNull(_logger = logger);
        }

        public async Task<string> GetUserInfoAsync(string accessToken)
        {
            //Log("Making API Call to Userinfo...");

            // builds the  request
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
