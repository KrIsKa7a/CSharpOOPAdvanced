using Logger.Models.Enums;
using Logger.Models.Interfaces;
using System;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private int messagesAppended;

        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = Level;
            this.File = file;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public IFile File { get; }

        public void Append(IError error)
        {
            var formattedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.File.Path, formattedMessage + Environment.NewLine);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}, File size: {this.File.Size}";
        }
    }
}
