using Dapper.FastCrud;
using Framework;
using Newtonsoft.Json;
using RanOnlineCore.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace RanOnlineCore.Action.CardModel
{
    public class CheckCardAction : CommandBase
    {
        protected override Result ExecuteCore(ObjectContext context)
        {
            var cards = context.RanUser.Find<Card>(state => state.Where($"status = @status").WithParameters(new
            {
                status = 99
            })).ToList();
            using (var http = new HttpClient())
            {
                foreach (var card in cards)
                {
                    var hash = "35ca55c425987ccdfcb96289d2ec662b".ToLower()
                + card.Code.ToLower()
                + "check".ToLower()
                + "6229117851".ToLower()
                + card.Id.ToLower()
                + card.Seri.ToLower()
                + card.Telco.ToUpper();
                    var signed = context.MD5Encode(hash).ToLower();

                    var dic = new Dictionary<string, string>
                    {
                        ["telco"] = card.Telco,
                        ["code"] = card.Code,
                        ["serial"] = card.Seri,
                        ["amount"] = card.Amount.ToString(),
                        ["partner_id"] = "6229117851",
                        ["sign"] = signed,
                        ["command"] = "check",
                        ["request_id"] = card.Id
                    };
                    var data = new FormUrlEncodedContent(dic);
                    var resultAsync = http.PostAsync("https://naptudong.com/chargingws/v2", data);
                    resultAsync.Wait();
                    var result = resultAsync.Result;
                    var contentAsync = result.Content.ReadAsStringAsync();
                    contentAsync.Wait();
                    var content = contentAsync.Result;
                    var res = JsonConvert.DeserializeObject<CardResult>(content);
                    if (res.status == 1)
                    {
                        card.Status = res.status;
                        card.Message = res.message;
                        context.RanUser.Update(card);

                        var user = context.RanUser.Find<UserInfo>(state => state.Where($"UserName = @username").WithParameters(new
                        {
                            username = card.Username
                        })).FirstOrDefault();
                        if (user != null)
                        {
                            user.UserPoint = user.UserPoint ?? 0;
                            user.UserPoint += card.Amount / 1000;
                            context.RanUser.Update(user);
                        }
                    }
                    else if(res.status != 99)
                    {
                        card.Status = res.status;
                        card.Message = res.message;
                        context.RanUser.Update(card);
                    }
                }
            }
            return Success();
        }
    }
}
