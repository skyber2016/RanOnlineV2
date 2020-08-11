using Dapper.FastCrud;
using Framework;
using Newtonsoft.Json;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.CardModel
{
    public class CardPostAction : CommandBase
    {
        public string telco { get; set; }
        public string code { get; set; }
        public string serial { get; set; }
        public long amount { get; set; }
        private string partner_id { get; set; }
        private string sign { get; set; }
        private string command { get; set; }
        private string Url = "https://naptudong.com/chargingws/v2";
        private HttpClient Client { get; set; }
        private string UID { get; set; }
        private IDictionary<string,string> dicTelco { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            this.dicTelco = new Dictionary<string, string>
            {
                ["VIETTEL"] = "VIETTEL",
                ["VINAPHONE"] = "VINAPHONE",
                ["MOBIFONE"] = "MOBIFONE",
                ["VTC"] = "VTC",
                ["GATE"] = "GATE",
                ["ZING"] = "ZING",
            };
            if (!this.dicTelco.ContainsKey(this.telco.ToUpper()))
            {
                throw new BadRequestException("Nhà mạng không chính xác!");
            }
            this.Client = new HttpClient();
            this.UID = this.GenUID();
            this.partner_id = "6229117851";
            this.command = $"charging";
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            var partner_key = "35ca55c425987ccdfcb96289d2ec662b";
            var hash = partner_key.ToLower() 
                + code.ToLower() 
                + command.ToLower()
                + partner_id.ToLower()
                + this.UID.ToLower()
                + serial.ToLower()
                + telco.ToUpper();
            this.sign = context.MD5Encode(hash).ToLower();
            context.RanUser.Insert(new Card
            {
                Id = this.UID,
                Code = this.code,
                Seri = this.serial,
                Status = false,
                Telco = this.telco,
                Username = context.User.Username,
                Message = "Đang chờ khởi tạo"
            });
            
        }
        private CardResult PostCard(ObjectContext context)
        {
            
            var dic = new Dictionary<string, string>
            {
                ["telco"] = telco,
                ["code"] = code,
                ["serial"] = serial,
                ["amount"] = amount.ToString(),
                ["partner_id"] = partner_id,
                ["sign"] = sign,
                ["command"] = command,
                ["request_id"] = this.UID
            };
            var data = new FormUrlEncodedContent(dic);
            var task = this.Client.PostAsync(this.Url, data);
            task.Wait();
            var json = task.Result.Content.ReadAsStringAsync();
            json.Wait();
            var result = JsonConvert.DeserializeObject<CardResult>(json.Result);
            context.RanUser.Update(new Card
            {
                Id = this.UID,
                Code = this.code,
                Seri = this.serial,
                Status = result.status == 1,
                Telco = this.telco,
                Username = context.User.Username,
                Message = result.message
            });
            if(result.status != 1)
            {
                throw new BadRequestException(result.message);
            }
            return result;
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            var card = this.PostCard(context);
            return Success();
        }
        private string GenUID()
        {
            string result = string.Empty;
            var baseChars = "abcdefghiklmnopqrstuvxyj0123456789";
            var value = (long)TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;

            int targetBase = baseChars.Length;

            do
            {
                result = baseChars[(int)(value % targetBase)] + result;
                value = value / targetBase;
            }
            while (value > 0);

            return result;
        }
    }
}
