using Logger.Models.Enums;
using Logger.Models.Errors;
using Logger.Models.Interfaces;
using System;
using System.Globalization;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string levelString, string date, string message)
        {
            bool hasParsed = Enum.TryParse(typeof(Level), levelString, out object result);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid Error Level!");
            }

            Level level = (Level)result;
            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(date, DateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid Date Format!", e);
            }

            return new Error(level, dateTime, message);
        }
    }
}
