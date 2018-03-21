using Logger.Factories;
using Logger.Models.Interfaces;
using System;

namespace Logger.Controllers
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            this.errorFactory = new ErrorFactory();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input
                    .Split('|');

                var level = inputArgs[0];
                var dateTimeString = inputArgs[1];
                var message = inputArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(level, dateTimeString, message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }

                this.logger.Log(error);
            }

            foreach (var appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
