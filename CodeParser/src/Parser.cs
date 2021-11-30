using System;

namespace CodeParser
{
    public class Parser
    {
        public string[] Lines(string data) => data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

    }
}