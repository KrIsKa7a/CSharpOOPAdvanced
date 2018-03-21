using Logger.Models.Interfaces;
using System.IO;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string folderPath;
        private string fileName;

        public IOManager(string folderPath, string fileName)
        {
            this.currentPath = GetCurrentPath();
            this.folderPath = folderPath;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => currentPath + folderPath;

        public string CurrentFilePath => currentPath + folderPath + fileName;

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(CurrentDirectoryPath))
            {
                Directory.CreateDirectory(currentPath + folderPath);
            }

            File.AppendAllText(CurrentFilePath, "");
        }
    }
}
