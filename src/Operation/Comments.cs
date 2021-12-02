using System;
using System.Collections.Generic;
using System.Linq;
using CodeParser.Operation;
using CodeParser.Operation.Interface;

// todo поработать еще, не совсем корректно получается результат
namespace CodeParser.Lines
{
    public class Comments : IOperation
    {
        private List<DataRegular> regular = new List<DataRegular>()
        {
            new DataRegular() {regular = "//", type = ReplaceType.Right},
            new DataRegular() {regular = "/**", type = ReplaceType.Right},
            new DataRegular() {regular = "/*", type = ReplaceType.Right},
            new DataRegular() {regular = "*/", type = ReplaceType.Right},
            new DataRegular() {regular = "*", type = ReplaceType.Left},
            new DataRegular() {regular = "<!--", type = ReplaceType.Right},
        };
        
        public string Process(string str, int number)
        {
            
            return Replace(str);
        }

        private string Replace(string str)
        {
            str = regular.Aggregate(str, (acc, op) => ReplaceSingle(acc,  op.regular, op.type));
            return str.Trim();
        }


        private string ReplaceSingle(string str, string search, ReplaceType type)
        {
           
            int index = str.IndexOf(search);
            
            if (index == -1) return str;
            
            var replaceStr = "";
            
            switch (type)
            {
                case ReplaceType.Left:
                    replaceStr = str.Substring(0, index + search.Length);
                    break;
                case ReplaceType.Right:
                    replaceStr = str.Substring(index + search.Length);
                    break;
            }
            
            return replaceStr;
        }
    }

    public enum ReplaceType
    {
        Left,
        Right
    }

    public class DataRegular
    {
        public string regular;
        public ReplaceType type;
    }
}