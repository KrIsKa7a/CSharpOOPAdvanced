using _04.WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WorkForce.Models.Employees
{
    public abstract class Employee : IWorker
    {
        protected Employee(string name, int hours)
        {
            this.Name = name;
            this.WorkHoursPerWeek = hours;
        }

        public string Name { get; }

        public int WorkHoursPerWeek { get; }
    }
}
