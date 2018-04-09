using _06.Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Twitter
{
    public class MicrowaveOven : IClient
    {
        private IServer server;

        public MicrowaveOven(IServer server)
        {
            this.server = server;
        }

        public bool ReceiveMessage(ITweet message)
        {
            Console.WriteLine(message);

            return server.ReceiveMessage(message);
        }
    }
}
