using System.Threading.Tasks;

namespace Gmail.Downloader.Lib.Repositories.Abstractions
{
    public interface IGoogleUserRepository
    {
        Task<string> GetUserInfoAsync(string accessToken);
    }
}