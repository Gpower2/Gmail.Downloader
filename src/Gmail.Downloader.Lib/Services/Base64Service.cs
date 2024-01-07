using System;
using System.Security.Cryptography;

namespace Gmail.Downloader.Lib.Services
{
    public static class Base64Service
    {
        /// <summary>
        /// Returns URI-safe data with a given input length.
        /// </summary>
        /// <param name="length">Input length (nb. output will be longer)</param>
        /// <returns></returns>
        public static string GenerateRandomDataBase64url(int length)
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(length);
            return EncodeBase64UrlWithNoPadding(bytes);
        }

        /// <summary>
        /// Base64url no-padding encodes the given input buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string EncodeBase64UrlWithNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Convert base64 to base64url
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            
            // Strip padding characters
            base64 = base64.Replace("=", "");

            return base64;
        }

        public static byte[] DecodeFromBase64Url(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            // Replace - with +
            input = input.Replace('-', '+');

            // Replace _ with /
            input = input.Replace('_', '/');

            // Check padding.
            switch (input.Length % 4)
            {
                case 0: // No pad characters.
                    break;
                case 2: // Two pad characters.
                    input += "==";
                    break;
                case 3: // One pad character.
                    input += "=";
                    break;
                default:
                    throw new FormatException("Invalid Base64 URL encoding!");
            }

            return Convert.FromBase64String(input);
        }
    }
}
