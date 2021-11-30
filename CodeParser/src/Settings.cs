using System;
using System.IO;
using Newtonsoft.Json;

namespace CodeParser
{
    public class Settings
    {
        private readonly string fileName;

        public Settings(string file)
        {
            fileName = file;
        }

        public DataSettings Get ()
        {
            
            try
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    DataSettings data = JsonConvert.DeserializeObject<DataSettings>(file.ReadToEnd());
                    return data;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        
    }
    public class DataSettings
    {
        public string Directory;
        public string ResultName;
        public string Types; // "js|ts|html"
        public int Filter;
    }
}