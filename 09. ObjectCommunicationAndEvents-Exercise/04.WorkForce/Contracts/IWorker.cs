using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WorkForce.Contracts
{
    public interface IWorker
    {
        string Name { get; }

        int WorkHoursPerWeek { get; }
    }
}
