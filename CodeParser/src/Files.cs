using System.IO;

namespace CodeParser
{
    public class Files
    {
        private string[] files;
        private string[] directory;
        
        public string[] GetFilesDirectory(string path)
        {
            files = Directory.GetFiles(path);
            return files;
        }

        private void GetAllDirectory(string path)
        {
            directory[0] = path;
            Directory.GetDirectories(path);
        }


    }
}