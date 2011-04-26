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
                using (Server server = new Server())
                {
                    server.Start();
                }
            
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
