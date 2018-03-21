using Logger.Models.Enums;
using System;

namespace Logger.Models.Interfaces
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}