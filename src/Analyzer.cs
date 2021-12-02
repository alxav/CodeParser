using System;
using System.IO;
using System.Linq;
using System.Text;
using CodeParser.Operation;
using CodeParser.Operation.Interface;

namespace CodeParser
{
    public class Analyzer
    {
        private string fileName;
        private IOperation[] operation;
        private Parser parser = new Parser();
        private string[] lines = new string[] { };

        public Analyzer(string fileName, IOperation[] operation)
        {
            this.fileName = fileName;
            this.operation = operation;
        }

        public void Start()
        {
            ReadFile(fileName);
            Operations(operation);
        }

        private void Operations(IOperation[] operation)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var number = i + 1;
                operation.Aggregate(line, (acc, op) => op.Process(acc.Trim(), number));
            }
        }

        private void ReadFile (string fileName)
        {
            FileStream fstream = null;
            try
            {
                using (fstream = File.OpenRead(fileName))
                {
                    byte[] array = new byte[fstream.Length];

                    fstream.Read(array, 0, array.Length);

                    var data = Encoding.UTF8.GetString(array);

                    lines = parser.Lines(data);
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
        }




    }
}