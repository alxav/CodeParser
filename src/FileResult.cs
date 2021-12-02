using System.Collections.Generic;
using System.IO;
using CodeParser.Lines;
using CodeParser.Operation;
using Newtonsoft.Json;

namespace CodeParser
{
    public class FileResult
    {
        private string fileNameResult;
        private Dictionary<string, List<DataLine>> dataResult = new Dictionary<string, List<DataLine>>();

        public FileResult(string fileNameResult)
        {
            this.fileNameResult = fileNameResult;
        }

        public void Add(string fileName, List<DataLine> lines)
        {
            if (!dataResult.ContainsKey(fileName))
            {
                dataResult.Add(fileName, new List<DataLine>());
            }

            dataResult[fileName] = lines;
        }

        public void Save()
        {
            
            using (StreamWriter sw = new StreamWriter(fileNameResult, false, System.Text.Encoding.UTF8))
            {
                var jsonStr = JsonConvert.SerializeObject(dataResult);
                sw.WriteLine(jsonStr);
            }
        }
    }
}