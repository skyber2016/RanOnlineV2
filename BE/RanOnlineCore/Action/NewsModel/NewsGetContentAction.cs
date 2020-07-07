using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetContentAction : CommandBase<dynamic>
    {
        public long? Id { get; set; }
        private News GetNews(ObjectContext context)
        {
            return context.RanMaster.Get(new News
            {
                Id = this.Id.Value
            }, state =>
                state.Include<Content>(s => s.LeftOuterJoin())
            ).IsDeletedFalse<News>();
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {

            var news = this.GetNews(context);
            return Success(new
            {
                id = news.Id,
                title = news.Title,
                created_date = news.CreatedDate,
                author = news.Author,
                content = news.Content.BodyText
            });
        }
    }
}
