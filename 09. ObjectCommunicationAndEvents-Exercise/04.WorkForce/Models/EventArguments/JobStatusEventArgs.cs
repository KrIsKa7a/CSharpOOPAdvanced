using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WorkForce.Models.EventArguments
{
    public class JobStatusEventArgs : EventArgs
    {
        public JobStatusEventArgs(string name, int hoursReamining)
        {
            this.Name = name;
            this.WorkHoursRemaining = hoursReamining;
        }

        public string Name { get; set; }

        public int WorkHoursRemaining { get; set; }
    }
}
