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
        private CommandHandler command_handler;
        private Thread thread_data;
        private Thread thread_command;
        private Queue<DataXMLPackage> queue_command;

        public Server()
        {
            config = new ConfigLoad();
            data_exchange = new DataExchange(this);
            command_handler = new CommandHandler(this);

            thread_data = new Thread(data_exchange.dataConector);// поток для приема и передачи данных
            thread_data.Start();
            thread_command = new Thread(command_handler.ReadCommandClient);// поток для обработки комманд клиента
            thread_command.Start();
        }

        public void Start()
        {
            System.Console.WriteLine("Сервер \"" + config.vars["S_SERVER_NAME"] + "\" запущен!");
            command_handler.ReadCommandConsole();
        }

        public void Dispose()
        {
            thread_data.Abort();
            thread_command.Abort();
        }
    }
}
