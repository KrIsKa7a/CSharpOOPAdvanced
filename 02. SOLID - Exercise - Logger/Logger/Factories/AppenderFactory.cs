using Logger.Models;
using Logger.Models.Appenders;
using Logger.Models.Enums;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender
            (string appendertype, string layoutType, string levelString)
        {
            bool hasParsed = Enum.TryParse(typeof(Level), levelString, out object result);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid Level Type");
            }

            Level level = (Level)result;

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            IAppender appender;

            switch (appendertype)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, level);
                    break;
                case "FileAppender":
                    var file = new LogFile();
                    appender = new FileAppender(layout, level, file);
                    break;
                default:
                    throw new ArgumentException("Invalid appender type!");
            }

            return appender;
        }
    }
}
