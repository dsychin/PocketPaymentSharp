using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PocketPaymentSharp
{
    public class RequestPayload
    {
        public RequestContent Request { get; set; }
        public string Signature { get; set; }

        public RequestPayload(Platform Platform, string clientId)
        {
            Request = new RequestContent();
            Request.Header = new Header(Platform, clientId);
        }

        public void GenerateSignature(string secret)
        {
            // get request as json string
            var requestString = JsonSerializer.Serialize(Request);

            // convert to bytes
            var encoding = new ASCIIEncoding();
            var secretBytes = encoding.GetBytes(secret);
            var requestBytes = encoding.GetBytes(requestString);

            // generate hash
            byte[] hashBytes;

            using (var hmac = new HMACSHA256(secretBytes))
                hashBytes = hmac.ComputeHash(requestBytes);
            Signature = BitConverter.ToString(hashBytes);
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}