using System;
using System.Text.RegularExpressions;
using CodeParser.Operation.Interface;

namespace CodeParser.Lines
{
    public class Ru: IOperation
    {
        private string regular = @"[а-я]";
        
        public string Process(string str, int number)
        {
            var isMach = Regex.IsMatch(str, regular, RegexOptions.IgnoreCase);
            if (isMach)
            {
                return str;
            }
            return "";
        }
    }
}