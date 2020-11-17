using System;
using PocketPaymentSharp;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientId = Environment.GetEnvironmentVariable("POCKET_CLIENT_ID");
            var secret = Environment.GetEnvironmentVariable("POCKET_SECRET");

            var client = new PocketClient(clientId, secret, Platform.Test);
        }

        static void CheckAuthExample(PocketClient client)
        {
            Console.WriteLine(client.CheckAuth());
        }
    }
}
