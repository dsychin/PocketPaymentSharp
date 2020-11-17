﻿using System;
using System.Threading.Tasks;
using PocketPaymentSharp;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientId = Environment.GetEnvironmentVariable("POCKET_CLIENT_ID");
            var secret = Environment.GetEnvironmentVariable("POCKET_SECRET");

            if (string.IsNullOrWhiteSpace(clientId))
            {
                Console.WriteLine("\"POCKET_CLIENT_ID\" environment variable is missing!");
                return;
            }

            if (string.IsNullOrWhiteSpace(secret))
            {
                Console.WriteLine("\"POCKET_SECRET\" environment variable is missing!");
                return;
            }

            var client = new PocketClient(clientId, secret, Platform.Test);
            CheckAuthExample(client).Wait();
        }

        static async Task CheckAuthExample(PocketClient client)
        {
            Console.WriteLine(await client.CheckAuthAsync());
        }
    }
}
