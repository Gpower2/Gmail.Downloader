using System.Security.Cryptography;
using System.Text;

namespace Gmail.Downloader.Lib.Extensions
{
    public static class CryptographyExtensions
    {
        /// <summary>
        /// Returns the SHA256 hash of the input string, which is assumed to be ASCII.
        /// </summary>
        public static byte[] GetSha256BytesFromAsciiText(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            return SHA256.HashData(bytes);
        }
    }
}
