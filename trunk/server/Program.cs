using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net;
using System.Net.Sockets;

using MySql.Data.MySqlClient;

using System.Timers;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConfigLoad config = new ConfigLoad();
                System.Console.WriteLine("Сервер \"" + config.vars["S_SERVER_NAME"] + "\" запущен!");
                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Для завершения работы нажмите любую клавишу!");
                System.Console.ReadLine();
            }
            
        }
    }
}
