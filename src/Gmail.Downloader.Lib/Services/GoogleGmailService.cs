using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Gmail.Downloader.Lib.Constants;
using Gmail.Downloader.Lib.Models;
using Gmail.Downloader.Lib.Repositories.Abstractions;
using Gmail.Downloader.Lib.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Gmail.Downloader.Lib.Services
{
    public class GoogleGmailService : IGoogleGmailService
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
        };

        private readonly IGoogleGmailRepository _googleGmailRepository;
        private readonly ILogger<GoogleGmailService> _logger;

        public GoogleGmailService(
            IGoogleGmailRepository googleGmailRepository,
            ILogger<GoogleGmailService> logger)
        {
            ArgumentNullException.ThrowIfNull(_googleGmailRepository = googleGmailRepository);
            ArgumentNullException.ThrowIfNull(_logger = logger);
        }

        public async Task<GmailLabel> GetCurrentUserLabelAsync(string accessToken, string labelId)
        {
            string response = await _googleGmailRepository.GetCurrentUserLabelAsync(accessToken, labelId);

            return JsonSerializer.Deserialize<GmailLabel>(response, _jsonSerializerOptions);
        }

        public async Task<GmailLabelList> GetCurrentUserLabelsAsync(string accessToken)
        {
            string response = await _googleGmailRepository.GetCurrentUserLabelsAsync(accessToken);

            return JsonSerializer.Deserialize<GmailLabelList>(response, _jsonSerializerOptions);
        }

        public async Task<GmailMessage> GetCurrentUserMessageAsync(string accessToken, string messageId, GoogleGmailFormat.MessageFormat messageFormat)
        {
            string response = await _googleGmailRepository.GetCurrentUserMessageAsync(accessToken, messageId, messageFormat);

            return JsonSerializer.Deserialize<GmailMessage>(response, _jsonSerializerOptions);
        }

        public async Task<GmailMessagePartBody> GetCurrentUserMessageAttachmentAsync(string accessToken, string messageId, string attachmentId)
        {
            string response = await _googleGmailRepository.GetCurrentUserMessageAttachmentAsync(accessToken, messageId, attachmentId);

            return JsonSerializer.Deserialize<GmailMessagePartBody>(response, _jsonSerializerOptions);
        }

        public async Task<GmailMessageList> GetCurrentUserMessagesAsync(string accessToken, string query, List<string> labels, string pageToken)
        {
            string response = await _googleGmailRepository.GetCurrentUserMessagesAsync(accessToken, query, labels, pageToken);

            return JsonSerializer.Deserialize<GmailMessageList>(response, _jsonSerializerOptions);
        }

        public async Task<GmailProfileInfo> GetCurrentUserProfileAsync(string accessToken)
        {
            string response = await _googleGmailRepository.GetCurrentUserProfileAsync(accessToken);

            return JsonSerializer.Deserialize<GmailProfileInfo>(response, _jsonSerializerOptions);
        }
    }
}
