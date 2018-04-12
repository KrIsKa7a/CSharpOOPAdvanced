using _04.WorkForce.Contracts;
using _04.WorkForce.Models.EventArguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WorkForce.Models
{
    public delegate void JobDoneEventHandler(object sender, JobDoneEventArgs args);
    public delegate void JobStatusEventHandler(object sender, JobStatusEventArgs args);

    public class Job : IJob
    {
        private event JobDoneEventHandler JobDone;
        private event JobStatusEventHandler JobStatus;

        public Job(IWorker employee, string name, int hoursRequired)
        {
            this.Employee = employee;
            this.Name = name;
            this.WorkHoursRequired = hoursRequired;
            this.IsDone = false;
            this.JobDone += JobDoneHandler;
            this.JobStatus += JobStatusHandler;
        }

        public IWorker Employee { get; }

        public string Name { get; }

        public int WorkHoursRequired { get; private set; }

        public bool IsDone { get; private set; }

        public void Update()
        {
            if (this.WorkHoursRequired - this.Employee.WorkHoursPerWeek <= 0)
            {
                this.OnJobDone();
                this.IsDone = true;
            }

            this.WorkHoursRequired -= this.Employee.WorkHoursPerWeek;
        }

        public void GetStatus()
        {
            this.OnStatus();
        }

        private void OnJobDone()
        {
            JobDone(this, new JobDoneEventArgs(this.Name));
        }

        private void JobDoneHandler(object sender, JobDoneEventArgs args)
        {
            Console.WriteLine($"Job {args.Name} done!");
        }

        private void OnStatus()
        {
            JobStatus(this, new JobStatusEventArgs(this.Name, this.WorkHoursRequired));
        }

        private void JobStatusHandler(object sender, JobStatusEventArgs args)
        {
            Console.WriteLine($"Job: {args.Name} Hours Remaining: {args.WorkHoursRemaining}");
        }
    }
}
