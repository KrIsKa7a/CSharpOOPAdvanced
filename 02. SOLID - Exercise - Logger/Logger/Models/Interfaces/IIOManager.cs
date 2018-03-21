using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Interfaces
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentPath();

        void EnsureDirectoryAndFileExists();
    }
}
