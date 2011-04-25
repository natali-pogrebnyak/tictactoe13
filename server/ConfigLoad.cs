using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Server
{
    class ConfigLoad
    {
        public string database;
        public string source;
        public string user;
        public string password;

        public ConfigLoad()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location; // путь до программы
            path = path.Substring(0, path.LastIndexOf("\\")); // срез имя файла
            ReadConfig(string.Format(@"{0}\config", path));
        }

        private void ReadConfig(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string value = sr.ReadLine().Trim().Replace(" ", string.Empty);
                        string key = value.Substring(0, value.IndexOf("=")).ToLower();
                        switch (key)
                        {
                            case "database":
                                this.database = value.Substring(value.IndexOf("=") + 1);
                                break;
                            case "source":
                                this.source = value.Substring(value.IndexOf("=") + 1);
                                break;
                            case "user":
                                this.user = value.Substring(value.IndexOf("=") + 1);
                                break;
                            case "password":
                                this.password = value.Substring(value.IndexOf("=") + 1);
                                break;
                        }
                    }
                }
            }
        }
    }
}
