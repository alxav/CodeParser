using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeParser
{
    public class Files
    {
        private string path;
        private string types;
        private List<string> files = new List<string>();

        public Files(string path, string types)
        {
            this.path = path;
            this.types = types;
        }

        public List<string> GetFiles()
        {
            DirectoryFiles(path);
            return files;
        }

        private bool Filter(string file)
        {
            if (types.Length == 0) return true;
            return Regex.IsMatch(file, @"\.(?:" + types + ")$", RegexOptions.IgnoreCase);
        }


        private void DirectoryFiles(string _path)
        {
            var _files = Directory.GetFiles(_path).Where((file) => Filter(file));

            foreach (var file in _files)
            {
                files.Add(file);
            }

            var childrenDirectory = Directory.GetDirectories(_path);

            foreach (var childDirectory in childrenDirectory)
            {
                DirectoryFiles(childDirectory);
            }
        }

    }
    
}