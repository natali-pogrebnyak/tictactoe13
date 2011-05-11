using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class CommandHandler
    {
        private Server server;
        private string str_command;
        private bool c_trg = true;

        public CommandHandler(Server ob_server)
        {
            server = ob_server;
        }

        public void ReadCommandConsole()
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

        public void ReadCommandClient()
        {
            bool c_trg = true;
            string str_command = "";
            while (c_trg)
            {
                switch (str_command)
                {
                    case "/exit":
                        System.Console.WriteLine("Команда " + str_command + " выполнена");
                        break;
                    default:
                        break;
                }
                System.Console.Write("->>");
            }
        }
    }
}
