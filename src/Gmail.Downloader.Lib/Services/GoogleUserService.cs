using System;
using System.Text.Json;
using System.Threading.Tasks;
using Gmail.Downloader.Lib.Models;
using Gmail.Downloader.Lib.Repositories.Abstractions;
using Gmail.Downloader.Lib.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Gmail.Downloader.Lib.Services
{
    public class GoogleUserService : IGoogleUserService
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
        };

        private readonly IGoogleUserRepository _googleUserRepository;
        private readonly ILogger<GoogleUserService> _logger;

        public GoogleUserService(
            IGoogleUserRepository googleUserRepository, 
            ILogger<GoogleUserService> logger)
        {
            ArgumentNullException.ThrowIfNull(_googleUserRepository = googleUserRepository);
            ArgumentNullException.ThrowIfNull(_logger = logger);
        }

        public async Task<GoogleUserInfo> GetUserInfoAsync(string accessToken)
        {
            string userInfoResponse = await _googleUserRepository.GetUserInfoAsync(accessToken);

            return JsonSerializer.Deserialize<GoogleUserInfo>(userInfoResponse, _jsonSerializerOptions);
        }
    }
}
