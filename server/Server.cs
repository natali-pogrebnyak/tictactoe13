using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class Server : IDisposable
    {
        private ConfigLoad config;

        public Server()
        {
            config = new ConfigLoad();
        }

        public void Start()
        {
            System.Console.WriteLine("Сервер \"" + config.vars["S_SERVER_NAME"] + "\" запущен!");
        }

        public void Dispose()
        {
        }
    }
}
