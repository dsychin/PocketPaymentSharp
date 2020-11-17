using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace PocketPaymentSharp
{
    public class PocketClient
    {
        private readonly string clientId;
        private readonly string secret;
        private readonly Platform platform;
        private readonly HttpClient http = new HttpClient();
        private readonly string endpointUrl = "https://pocket.com.bn/api/request.php";

        public PocketClient(string clientId, string secret, Platform platform = Platform.Test)
        {
            this.clientId = clientId;
            this.secret = secret;
            this.platform = platform;
        }

        // TODO: add proper response object
        public async Task<string> CheckAuthAsync()
        {
            // build request
            var payload = new RequestPayload(platform, clientId);
            payload.Request.Header.Service = "security.checkauth";
            payload.GenerateSignature(secret);

            var jsonPayload = payload.GetJson();

            // submit request
            var content = new StringContent(jsonPayload);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await http.PostAsync(endpointUrl, content);

            // print response
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync(); // return json for debugging
        }
    }
}
