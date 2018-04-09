using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Twitter.Contracts
{
    public interface ITweet
    {
        string MessageText { get; }

        string RetrieveMessage();
    }
}
