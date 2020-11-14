namespace PocketPaymentSharp
{
    public class RequestPayload
    {
        public RequestContent Request { get; set; }
        public string Signature { get; set; }
    }
}