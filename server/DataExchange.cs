using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net;
using System.Net.Sockets;

using System.Xml;
using System.Xml.Serialization;

namespace Server
{
    class DataExchange
    {
        private Server server;
        private Socket mysocket;
        private IPEndPoint sender;
        static EndPoint Remote;
        private DataXMLPackage client_command;

        public DataExchange(Server ob_server)
        {
            server = ob_server;
            mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mysocket.Bind(new IPEndPoint(IPAddress.Any, 9050));
            sender = new IPEndPoint(IPAddress.Any, 0);
            Remote = (EndPoint)(sender);
        }

        public void dataConector()
        {
            byte[] data_in;
            int recv = 0;
            XmlSerializer xmlFormat = new XmlSerializer(typeof(DataXMLPackage));

            while (true)
            {
                try
                {
                    data_in = new byte[1024];
                    recv = mysocket.ReceiveFrom(data_in, ref Remote);
                    
                    TextReader stringReader = new StringReader(Encoding.Default.GetString(data_in, 0, recv));
                    client_command = (DataXMLPackage)xmlFormat.Deserialize(stringReader);
                    client_command.d_date_r = String.Format("{0:dd.MM.yyyy HH:mm:ss}", DateTime.Now);
                    server.queue_command.Enqueue(client_command);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                
            }
        }

        public void Stop()
        {
            mysocket.Close();
        }

    }
}
