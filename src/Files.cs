using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeParser
{
    public class Files
    {
        private string path;
        private string types;
        private List<string> files = new List<string>();
        private Parser parser = new Parser();
        private Filter filter;

        public Files(string path, string types, int filter)
        {
            this.path = path;
            this.types = types;
            this.filter = new Filter(filter);
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


        public List<DataLine> Read(string file)
        {
            List<DataLine> result = new List<DataLine>();
            FileStream fstream = null;
            try
            {
                using (fstream = File.OpenRead(file))
                {
                    byte[] array = new byte[fstream.Length];

                    fstream.Read(array, 0, array.Length);

                    var data = Encoding.UTF8.GetString(array);

                    var lines = parser
                        .Lines(data);

                    for (var i = 0; i < lines.Length; i++)
                    {
                        var str = lines[i];
                        var number = i + 1;


                        if (filter.Comparison(str))
                        {
                            result.Add(new DataLine()
                            {
                                number = number,
                                text = str
                            });
                        }
                          
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (fstream != null)
                    fstream.Close();
            }

            return result;
        }
    }

    public class DataLine
    {
        public int number;
        public string text;
    }
}