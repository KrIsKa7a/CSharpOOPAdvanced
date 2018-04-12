using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models.Contracts
{
    public interface ISlave
    {
        string Name { get; }

        void Respond();
    }
}
