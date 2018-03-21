using Logger.Models.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using Logger.Models.IOManagement;

namespace Logger.Models
{
    public class LogFile : IFile
    {
        private const string folderPath = "\\data\\";
        private const string fileName = "filedata.txt";

        private string currentPath;
        private IOManager ioManager;

        public LogFile()
        {
            this.ioManager = new IOManager(folderPath, fileName);
            currentPath = this.ioManager.GetCurrentPath();
            this.ioManager.EnsureDirectoryAndFileExists();
            this.Path = currentPath + folderPath + fileName;
        }


        public string Path { get; }

        public int Size => GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            var format = layout.Format;
            var dateTime = error.DateTime;
            var level = error.Level;
            var message = error.Message;

            var formattedMessage =
                String.Format(format,
                dateTime.ToString("M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            return formattedMessage;
        }

        private int GetFileSize()
        {
            var text = File.ReadAllText(this.Path);

            return text.ToCharArray()
				.Where(c => Char.IsLetter(c))
                .Sum(c => (int)c);
        }
    }
}
