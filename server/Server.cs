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
        public Queue<DataXMLPackage> queue_command;

        public Server()
        {

        }

        public void Start()
        {
            config = new ConfigLoad();
            data_exchange = new DataExchange(this);
            command_handler = new CommandHandler(this);
            queue_command = new Queue<DataXMLPackage>();

            thread_data = new Thread(data_exchange.dataConector);// поток для приема и передачи данных
            thread_data.Start();
            thread_command = new Thread(command_handler.ReadCommandClient);// поток для обработки комманд клиента
            thread_command.Start();

            System.Console.WriteLine("Сервер \"" + config.vars["S_SERVER_NAME"] + "\" запущен!");
            command_handler.ReadCommandConsole();
        }

        public void Stop()
        {
            thread_data.Abort();
            thread_command.Abort();
            data_exchange.Stop();
        }

        public void Dispose()
        {
            thread_data.Abort();
            thread_command.Abort();
        }
    }
}
