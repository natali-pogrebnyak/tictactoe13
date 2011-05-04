using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace Server
{
    class Server : IDisposable
    {
        private ConfigLoad config;
        private DataExchange data_exchange;
        private Thread thread_command;

        public Server()
        {
            config = new ConfigLoad();
            data_exchange = new DataExchange(this);
            this.thread_command = new Thread(this.data_exchange.dataConector);
            this.thread_command.Start();
        }

        public void Start()
        {
            System.Console.WriteLine("Сервер \"" + config.vars["S_SERVER_NAME"] + "\" запущен!");
            ReadCommand();
        }

        private void ReadCommand()
        {
            bool c_trg = true;
            string str_command;
            System.Console.Write("->>");
            while (c_trg)
            {
                str_command = System.Console.ReadLine().ToString().ToLower().Trim();
                switch (str_command)
                {
                    case "/exit":
                        c_trg = false;
                        System.Console.WriteLine("Команда " + str_command + " выполнена");
                        break;
                    case "/stop":
                        c_trg = false;
                        System.Console.WriteLine("Команда " + str_command + " выполнена");
                        break;
                    case "/restart":
                        System.Console.WriteLine("Команда " + str_command + " не реализована!");
                        break;
                    case "/?":
                        System.Console.WriteLine("Список команд сервера:");
                        System.Console.WriteLine("/exit - остановка сервера");
                        System.Console.WriteLine("/stop - остановка сервера");
                        System.Console.WriteLine("/restart - перезапуск сервера");
                        break;
                    case "/help":
                        System.Console.WriteLine("Список команд сервера:");
                        System.Console.WriteLine("/exit - остановка сервера");
                        System.Console.WriteLine("/stop - остановка сервера");
                        System.Console.WriteLine("/restart - перезапуск сервера");
                        break;
                    default:
                        System.Console.WriteLine("Команда не определена! воспользуйтесь командой /? или /help");
                        break;
                }
                System.Console.Write("->>");
            }
        }

        public void Dispose()
        {
            thread_command.Abort();
        }
    }
}
