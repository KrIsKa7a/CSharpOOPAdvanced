using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WorkForce.Models.EventArguments
{
    public class JobDoneEventArgs : EventArgs
    {
        public JobDoneEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
