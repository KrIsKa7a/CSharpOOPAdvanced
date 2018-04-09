using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Twitter.Contracts
{
    public interface IClient
    {
        /// <summary>
        /// Returns true if the message is successfully received and passed to the server
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool ReceiveMessage(ITweet message);
    }
}
