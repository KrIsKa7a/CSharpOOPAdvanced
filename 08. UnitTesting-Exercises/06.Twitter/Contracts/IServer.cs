using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Twitter.Contracts
{
    public interface IServer
    {
        /// <summary>
        /// Returns true if the message is successfully received by the current server
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool ReceiveMessage(ITweet message);
    }
}
