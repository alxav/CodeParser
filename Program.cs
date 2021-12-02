using System;
using CodeParser.Lines;
using CodeParser.Operation;
using CodeParser.Operation.Interface;

namespace CodeParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var settings = new Settings("settings.json");
            settings.Load();

            var files = new Files(settings.Directory, settings.Types);

            var fileList = files.GetFiles();

            if (fileList.Count == 0)
            {
                Console.WriteLine("Files not found!");
                return;
            }

            var fileResult = new FileResult(settings.ResultName);
            
            foreach (var fileName in fileList)
            {
                var comment = new Comments();
                var ru = new Ru();
                var format = new Format();

                var operation = new IOperation[] { comment, ru, format };

                var analyzer = new Analyzer(fileName, operation);
                analyzer.Start();
                
                if (format.Result().Count == 0) continue;
                
                fileResult.Add(fileName, format.Result());
            }

            fileResult.Save();
        }
    }
}