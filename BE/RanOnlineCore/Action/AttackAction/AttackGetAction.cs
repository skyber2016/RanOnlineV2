using Framework;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.AttackAction
{
    public class AttackGetAction : CommandBase<dynamic>
    {
        private SimpleTcpClient Client { get; set; }
        private byte[] Data { get; set; }
        private List<string> Messages { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            this.Client = new SimpleTcpClient();
            this.Messages = new List<string>();
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            this.Client.DataReceived += Client_DataReceived;
            this.Data = Enumerable.Range(0, 10000).Select(x => Convert.ToByte(255)).ToArray();

        }
        private void Add(string mess)
        {
            this.Messages.Add(mess);
        }
        private void Client_DataReceived(object sender, Message e)
        {
            this.Data = e.Data;
            this.Add("[RECEIVED] " + e.MessageString);
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
            return Success(new {
                request_id = context.RequestId,
                time_start = ObjectContext.TimeStart.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                messages = ObjectContext.Messages
            });
        }
    }
}
