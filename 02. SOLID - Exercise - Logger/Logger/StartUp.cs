using System;
using System.Collections.Generic;
using Logger.Controllers;
using Logger.Factories;
using Logger.Models.Interfaces;

namespace Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var appendersCount = int.Parse(Console.ReadLine());
            var appenderFactory = new AppenderFactory();

            ICollection<IAppender> appenders = new List<IAppender>();
            ParseAppendersInput(appendersCount, appenderFactory, appenders);

            var logger = new Logger.Models.Logger(appenders);

            var engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppendersInput(int appendersCount, AppenderFactory appenderFactory, ICollection<IAppender> appenders)
        {
            for (int counter = 0; counter < appendersCount; counter++)
            {
                var appendersArgs = Console.ReadLine()
                    .Split(' ');

                var type = appendersArgs[0];
                var layout = appendersArgs[1];
                var level = "INFO";

                if (appendersArgs.Length == 3)
                {
                    level = appendersArgs[2];
                }

                IAppender currentAppender;

                try
                {
                    currentAppender = appenderFactory.GetAppender(type, layout, level);
                    appenders.Add(currentAppender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
