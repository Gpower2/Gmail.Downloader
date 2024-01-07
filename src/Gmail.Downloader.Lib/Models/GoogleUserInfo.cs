using System.Text.Json.Serialization;

namespace Gmail.Downloader.Lib.Models
{
    public class GoogleUserInfo
    {
        public string Sub { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }
        
        public string Picture { get; set; }

        public string Locale { get; set; }
    }
}
