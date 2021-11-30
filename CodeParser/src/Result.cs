using System.IO;

namespace CodeParser
{

    public class Result
    {
        private StreamWriter streamWriter;
        private string fileName;

        public Result(string name)
        {
            fileName = name;
        }


        public void Open()
        {
            streamWriter = new StreamWriter(fileName);
        }

        public void Close()
        {
            streamWriter.Close();
        }


        public void WriteHead(string file, int count)
        {
            streamWriter.WriteLine("");
            streamWriter.WriteLine(file + $". ({count})");
            streamWriter.WriteLine("");
        }

        public void WriteLine(int number, string text)
        {
            var str = $"({number}) {text}";
            streamWriter.WriteLine(str);
        }


    }
}