using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WorkForce.Contracts
{
    public interface IJob
    {
        IWorker Employee { get; }

        string Name { get; }

        int WorkHoursRequired { get; }

        bool IsDone { get; }

        void Update();

        void GetStatus();
    }
}
