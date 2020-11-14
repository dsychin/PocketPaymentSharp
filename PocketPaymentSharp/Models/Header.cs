using System.Text.Json.Serialization;

namespace PocketPaymentSharp
{
    public class Header
    {
        public string Platform { get; set; }
        public string Version { get; set; }
        public string Service { get; set; }
        [JsonPropertyName("clientID")]
        public string ClientId { get; set; }
        [JsonPropertyName("reqTime")]
        public string RequestTime { get; set; }
    }
}