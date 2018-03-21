using Logger.Models.Enums;
using Logger.Models.Interfaces;
using System;

namespace Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(Level level, DateTime dateTime, string message)
        {
            this.Level = level;
            this.DateTime = dateTime;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
