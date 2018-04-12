using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models
{
    public class RespondEventArgs : EventArgs
    {
        public RespondEventArgs(string name)
        {
            this.Name = name;
        }
        
        public string Name { get; }
    }
}
