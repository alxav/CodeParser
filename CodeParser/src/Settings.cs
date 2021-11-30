using System;
using System.IO;

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
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    return new DataSettings();
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
    }
}