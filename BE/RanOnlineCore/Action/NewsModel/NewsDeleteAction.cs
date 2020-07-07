using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsDeleteAction : CommandBase
    {
        public long? Id { get; set; }
        private bool Delete(ObjectContext context, News news) {
            news.IsDeleted = true;
            return context.RanMaster.Update(news);
        }
        private News GetNews(ObjectContext context)
        {
            return context.RanMaster.Get(new News { Id = this.Id.Value });
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            var news = this.GetNews(context);
            if(news != null)
            {
                this.Delete(context, news);
            }
            return Success();
        }
    }
}
