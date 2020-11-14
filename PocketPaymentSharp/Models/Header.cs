using System.Text.Json.Serialization;
using System;

namespace PocketPaymentSharp
{
    public class Header
    {
        public string Platform { get; set; }
        public string Version { get; } = "1.3.2";
        public string Service { get; set; }
        [JsonPropertyName("clientID")] public string ClientId { get; set; }
        [JsonPropertyName("reqTime")] public string RequestTime { get; set; }

        public Header(Platform Platform, string clientId)
        {
            this.ClientId = clientId;

            // set platform type
            switch (Platform)
            {
                case Platform.Test:
                    this.Platform = "test";
                    break;
                case Platform.Live:
                    this.Platform = "live";
                    break;
            }

            // set request time
            var utcTime = DateTime.UtcNow;
            var sstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            this.RequestTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, sstTimeZone)
                .ToString("yyyy-MM-ddTHH:mm:ff");
        }
    }
}