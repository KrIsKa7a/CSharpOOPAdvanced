using Logger.Models.Enums;
using Logger.Models.Interfaces;
using System;
using System.Globalization;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private int messagesAppended;

        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public void Append(IError error)
        {
            var format = this.Layout.Format;
            var dateTime = error.DateTime;
            var level = error.Level;
            var message = error.Message;

            var formattedMessage =
                String.Format(format,
                dateTime.ToString("M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formattedMessage);
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
