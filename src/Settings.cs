using System;
using System.IO;
using Newtonsoft.Json;

namespace CodeParser
{
    public class Settings
    {
        private readonly string fileName;

        private string directory;
        private string resultName;
        private string types;
        private int filter;
        
        
        public Settings(string file)
        {
            fileName = file;
        }

        
        public void Load()
        {
            
            try
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    DataSettings data = JsonConvert.DeserializeObject<DataSettings>(file.ReadToEnd());

                    directory = data.Directory;
                    resultName = data.ResultName;
                    types = data.Types;
                    filter = data.Filter;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public string Directory => directory;
        public string ResultName => resultName;

        public string Types => types;

        public int Filter => filter;
    }
    public class DataSettings
    {
        public string Directory;
        public string ResultName;
        public string Types; // "js|ts|html"
        public int Filter;
    }
}