using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gmail.Downloader.Lib.Models
{
    public class GoogleClientSecretContent
    {
        [JsonPropertyName("installed")]
        public GoogleClientSecret Installed { get; set; }
    }

    public class GoogleClientSecret
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("auth_uri")]
        public string AuthUri { get; set; }

        [JsonPropertyName("token_uri")]
        public string TokenUri { get; set; }

        [JsonPropertyName("auth_provider_x509_cert_url")]
        public string AuthProviderX509CertUrl { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("redirect_uris")]
        public List<string> RedirectUris { get; set; }
    }
}
