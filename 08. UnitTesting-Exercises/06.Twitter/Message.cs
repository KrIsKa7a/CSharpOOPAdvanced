using _06.Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Twitter
{
    public class Message : ITweet
    {
        public Message(string message)
        {
            this.MessageText = message;
        }

        public string MessageText { get; }

        public string RetrieveMessage()
        {
            if (String.IsNullOrWhiteSpace(this.MessageText))
            {
                throw new InvalidOperationException("Message cannot be null or whitespace!");
            }

            return this.MessageText;
        }
    }
}
