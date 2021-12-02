using System;
using System.Collections.Generic;
using System.IO;

namespace CodeParser
{
    public class Result
    {
        private Dictionary<string, List<LineData>> lines = new Dictionary<string, List<LineData>>();
        private StreamWriter streamWriter;
        private string fileName;

        public Result(string name)
        {
            fileName = name;
        }


        public void Open()
        {
            streamWriter = new StreamWriter(fileName);
        }

        public void Close()
        {
            streamWriter.Close();
        }


        public void WriteHead(string file, int count)
        {
            streamWriter.WriteLine("");
            streamWriter.WriteLine(file + $". ({count})");
            streamWriter.WriteLine("");
        }

        public void WriteLine(int number, string text)
        {
            var str = $"  ({number}) {text.Trim()}";
            streamWriter.WriteLine(str);
        }

        public void WriteStatistic(int countFile, int countLine, DateTime start, DateTime finish, Settings settings)
        {
            var str = $"{Environment.NewLine}Статистика {Environment.NewLine} " +
                      $"Кол. обработанных файлов: {countFile} {Environment.NewLine} " +
                      $"Кол. найденных строк: {countLine} {Environment.NewLine} " +
                      $"Время начала: {start:dd.MM.yyyy hh:mm:ss} {Environment.NewLine} " +
                      $"Время окончания: {finish:dd.MM.yyyy hh:mm:ss} {Environment.NewLine}";

            var strSetting = $"{Environment.NewLine}Настройки {Environment.NewLine} " +
                             $"Директория: {settings.Directory} {Environment.NewLine} " +
                             $"Типы обрабатываемых файлов: {settings.Types} {Environment.NewLine}";
            
            streamWriter.WriteLine(str + strSetting);
        }
    }

    public class LineData
    {
        public int number;
        public string text;
        public int isIgnore;
    }
}