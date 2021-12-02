using System.Collections.Generic;
using CodeParser.Operation.Interface;

namespace CodeParser.Operation
{
    public class Format : IOperation
    {
        private List<DataLine> lines = new List<DataLine>();

        public string Process(string str, int number)
        {
            str = str.Trim();

            if (str != "") Add(str, number);

            return str;
        }

        public List<DataLine> Result() => lines;

        private void Add(string str, int number)
        {
            var data = new DataLine()
            {
                number = number,
                text = str,
                isIgnore = 0
            };

            lines.Add(data);
        }
        
    }
    
    public class DataLine
    {
        public int number;
        public string text;
        public int isIgnore;
    }
}