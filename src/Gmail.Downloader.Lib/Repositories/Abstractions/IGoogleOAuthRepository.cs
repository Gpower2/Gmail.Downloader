using System.Threading.Tasks;

namespace Gmail.Downloader.Lib.Repositories.Abstractions
{
    public interface IGoogleOAuthRepository
    {
        Task<string> DoOAuthAsync(string clientId, string clientSecret);
        Task<string> ExchangeCodeForTokensAsync(string code, string codeVerifier, string redirectUri, string clientId, string clientSecret);
    }
}