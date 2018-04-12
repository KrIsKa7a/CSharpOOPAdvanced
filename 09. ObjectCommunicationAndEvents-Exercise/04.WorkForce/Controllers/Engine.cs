using _04.WorkForce.Contracts;
using _04.WorkForce.Models;
using _04.WorkForce.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.WorkForce.Controllers
{
    public class Engine
    {
        private List<IWorker> employees;
        private List<IJob> jobs;

        public Engine()
        {
            this.employees = new List<IWorker>();
            this.jobs = new List<IJob>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input
                    .Split();

                switch (inputArgs[0])
                {
                    case "Job":
                        AddJob(inputArgs);
                        break;
                    case "StandardEmployee":
                        AddStandartEmployee(inputArgs);
                        break;
                    case "PartTimeEmployee":
                        AddPartTimeEmployee(inputArgs);
                        break;
                    case "Pass":
                        PassWeek();
                        break;
                    case "Status":
                        GetStatus();
                        break;
                }
            }
        }

        private void GetStatus()
        {
            foreach (var job in this.jobs)
            {
                if (!job.IsDone)
                {
                    job.GetStatus();
                }
            }
        }

        private void PassWeek()
        {
            foreach (var job in this.jobs)
            {
                if (!job.IsDone)
                {
                    job.Update();
                }
            }
        }

        private void AddPartTimeEmployee(string[] inputArgs)
        {
            var name = inputArgs[1];

            var emloyee = new PartTimeEmployee(name);

            this.employees.Add(emloyee);
        }

        private void AddStandartEmployee(string[] inputArgs)
        {
            var name = inputArgs[1];

            var emloyee = new StandartEmployee(name);

            this.employees.Add(emloyee);
        }

        private void AddJob(string[] inputArgs)
        {
            var nameOfJob = inputArgs[1];
            var hoursRequired = int.Parse(inputArgs[2]);
            var employeeName = inputArgs[3];
            var jobEmployee = this.employees
                .First(e => e.Name == employeeName);

            var job = new Job(jobEmployee, nameOfJob, hoursRequired);

            this.jobs.Add(job);
        }
    }
}
