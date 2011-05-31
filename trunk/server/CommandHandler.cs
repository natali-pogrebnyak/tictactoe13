using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class CommandHandler
    {
        private Server server;
        private string console_command;
        private DataXMLPackage client_command;

        public CommandHandler(Server ob_server)
        {
            server = ob_server;
        }

        public void ReadCommandConsole()
        {
            bool c_trg = true;
            System.Console.Write("->>");
            while (c_trg)
            {
                console_command = System.Console.ReadLine().ToString().ToLower().Trim();
                switch (console_command)
                {
                    case "/exit":
                        c_trg = false;
                        server.Stop();
                        System.Console.WriteLine("Команда " + console_command + " выполнена");
                        break;
                    case "/stop":
                        c_trg = false;
                        server.Stop();
                        System.Console.WriteLine("Команда " + console_command + " выполнена");
                        break;
                    case "/restart":
                        System.Console.WriteLine("Команда " + console_command + " не реализована!");
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
            while (c_trg)
            {
                if(server.queue_command.Count() > 0)
                {
                    client_command = server.queue_command.Dequeue();
                    switch (client_command.s_data)
                    {
                        case "/test":// тест соеденения
                            break;
                        case "/login":// регистрация пользователя в системе
                            break;
                        case "/get_players":// запрос на всех играков в онлаине
                            break;
                        case "/set_player":// установка игрока противника
                            break;
                        case "/set_result":// установка результата
                            break;
                        case "/logout":// выход из системы
                            break;
                        default:
                            break;
                    }
                    System.Console.WriteLine("Команда " + client_command.s_data + " выполнена");
                }
            }
        }
    }
}
