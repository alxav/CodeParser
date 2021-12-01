using System;

namespace CodeParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            
            var setting = new Settings("settings.json").Get();
            
            var files = new Files(setting.Directory, setting.Types, setting.Filter);
            var result = new Result(setting.ResultName);
            
            var list = files.GetFiles();

            if (list.Count == 0)
            {
                Console.WriteLine("Files not found!");
                return;
            }


            result.Open();
            var countLine = 0;
            
            foreach (var element in list)
            {

                var lines = files.Read(element);
                
                if (lines.Count == 0) continue;

                countLine += lines.Count;

                result.WriteHead(element, lines.Count);
                
                lines.ForEach((line) =>
                {
                    result.WriteLine(line.number , line.text);
                });

            }
            
            var finishTime = DateTime.Now;

            result.WriteStatistic(list.Count, countLine, startTime, finishTime, setting);
            
            result.Close();
            
        }
    }
}

