using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using MySql.Data.MySqlClient;

namespace Server
{
    class ConfigLoad
    {
        public string database;
        public string source;
        public string user;
        public string password;
        public Dictionary<string, object> vars = new Dictionary<string, object>();

        public ConfigLoad()
        {
            System.Console.Write("Конфигурация сервера");
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location; // путь до программы
            path = path.Substring(0, path.LastIndexOf("\\")); // срез имя файла
            readConfig(string.Format(@"{0}\config", path));
            //readVars();
            System.Console.WriteLine(" ... OK");
        }

        private void readConfig(string path)
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

        public string dataSourse
        {
            get
            {
                return string.Format(@"Database={0};Data Source={1};User Id={2};Password={3}", database, source, user, password); // строка коннекта
            }
        }

        public void readVars()
        {
            string sql = "SELECT S_SYS_NAME, S_TYPE, S_VALUE FROM dat_vars";
            MySqlConnection connection = new MySqlConnection(dataSourse);
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader data_reader;
            connection.Open();
            data_reader = command.ExecuteReader();
            while (data_reader.Read())
            {
                switch (data_reader.GetString(1).Trim().ToLower())
                {
                    case "string":
                        vars[data_reader.GetString(0)] = data_reader.GetString(2);
                        break;
                    case "int":
                        vars[data_reader.GetString(0)] = data_reader.GetInt32(2);
                        break;
                    default:
                        vars[data_reader.GetString(0)] = data_reader.GetString(2);
                        break;
                }
                
            }
            data_reader.Close();
            connection.Close(); //Обязательно закрываем соединение!
        }
    }
}
