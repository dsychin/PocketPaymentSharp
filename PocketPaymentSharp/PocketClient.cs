namespace PocketPaymentSharp
{
    public class PocketClient
    {
        private readonly string clientId;
        private readonly string secret;
        private readonly Platform platform;
        private readonly string version = "1.3.2";

        public PocketClient(string clientId, string secret, Platform platform = Platform.Test)
        {
            this.clientId = clientId;
            this.secret = secret;
            this.platform = platform;
        }
    }
}
