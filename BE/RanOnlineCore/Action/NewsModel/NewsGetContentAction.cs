using Dapper.FastCrud;
using Framework;
using Framework.Extensions;
using Newtonsoft.Json.Linq;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RanOnlineCore.Entity.ZaloArticle;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetContentAction : CommandBase<dynamic>
    {
        public string Id { get; set; }
        private Zalo<Article> GetNews(ObjectContext context)
        {
            JObject json =  context.ZaloClient.getdetailArticle(this.Id);
            return json.ToObject<Zalo<Article>>();
        }
        private IEnumerable<dynamic> GetNewsFriend(ObjectContext context)
        {
            using(var cmd = new NewsGetAction())
            {
                return cmd.Execute(context).ThrowIfFail();
            }
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {

            var news = this.GetNews(context).data;
            var newFriend = this.GetNewsFriend(context);
            return Success(new
            {
                id = news.id,
                title = news.title,
                short_text = news.description,
                created_date = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                author = news.author,
                content = news.body,
                friends = newFriend
            });
        }
    }
}
