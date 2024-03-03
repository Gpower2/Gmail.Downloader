using System.Threading.Tasks;
using Gmail.Downloader.Lib.Models;

namespace Gmail.Downloader.Lib.Services.Abstractions
{
    public interface IGoogleUserService
    {
        Task<GoogleUserInfo> GetUserInfoAsync(string accessToken);
    }
}