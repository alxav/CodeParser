using System;
using System.Text.RegularExpressions;

namespace CodeParser
{
    public enum Filters
    {
        All,
        Comment,
        CodeRuText
    }

    public class Filter
    {
        private int filter;

        public Filter(int filter)
        {
            this.filter = filter;
        }

        public bool Comparison(string text)
        {
            switch (filter)
            {
                case (int)Filters.Comment:
                    return IsComment(text);
                case (int)Filters.CodeRuText:
                    return IsCodeRuText(text);
                default:
                    return true;
            }
        }

        private bool IsComment(string text)
        {
            var str = text.Trim();

            var jsComments = Regex.IsMatch(str, @"\/\/|\/\*\*|\*\/|^\*", RegexOptions.IgnoreCase);
            var htmlComments = Regex.IsMatch(str, @"^\<!--", RegexOptions.IgnoreCase);
            
            return jsComments || htmlComments;
        }

        private bool IsCodeRuText(string text)
        {
            var str = text.Trim();
            var isTranslateServiceRu = Regex.IsMatch(str, @"instant\('[а-я]", RegexOptions.IgnoreCase);
            var isRu = Regex.IsMatch(str, @"[а-я]", RegexOptions.IgnoreCase);
            var result = !IsComment(str) && (isTranslateServiceRu || isRu);
            return result;
        }
    }
}