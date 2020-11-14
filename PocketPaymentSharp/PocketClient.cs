namespace PocketPaymentSharp
{
    public class PocketClient
    {
        private readonly string clientId;
        private readonly string secret;
        private readonly Platform platform;

        public PocketClient(string clientId, string secret, Platform platform = Platform.Test)
        {
            this.clientId = clientId;
            this.secret = secret;
            this.platform = platform;
        }

        // TODO: add proper response object
        public string CheckAuth()
        {
            // build request
            var payload = new RequestPayload(platform, clientId);
            payload.GenerateSignature(secret);

            var jsonPayload = payload.GetJson();
            // submit request

            // print response
            return jsonPayload;
        }
    }
}
