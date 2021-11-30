using System;

namespace CodeParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var setting = new Settings("settings.json").Get();
            
            var files = new Files(setting.Directory, setting.Types);
            var result = new Result(setting.ResultName);
            
            var list = files.GetFiles();

            if (list.Count == 0)
            {
                Console.WriteLine("Files not found!");
                return;
            }


            result.Open();
            
            foreach (var element in list)
            {

                var lines = files.Read(element);
                
                result.WriteHead(element, lines.Length);
                
                for (var i = 0; i < lines.Length; i++)
                {
                    var number = i + 1;
                    result.WriteLine(number, lines[i]);
                }
                
            }
            
            
            result.Close();
            
        }
    }
}

