using System;

namespace CodeParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var file = new Files();
            var list = file.GetFilesDirectory("/");

            foreach (var el in list)
            {
                Console.WriteLine(el);
            }
            
        }
    }
}

