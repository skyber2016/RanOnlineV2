using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System.Collections.Generic;
using System.Linq;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetAction : CommandBase<dynamic>
    {
        public long CategoryId { get; set; }
        public long? CurrentPage { get; set; } = 1;
        private long? PageSize { get; set; } = 5;
        private IEnumerable<News> GetNews(ObjectContext context)
        {
            var offset = (this.CurrentPage.Value -1) * this.PageSize.Value;
            return context
                .RanMaster
                .Find<News>(
                    state => 
                    state
                    .IsDeletedFalse()
                    .Where($"CategoryId = @CategoryId")
                    .WithParameters(new {
                        this.CategoryId
                    })
                    .OrderByDesc()
                    .Skip(offset)
                    .Top(this.PageSize.Value)
                    )
                    ;
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {

            var listNews = this.GetNews(context);
            return Success(listNews.Select(news => new {
                id = news.Id,
                title = news.Title,
                image = news.Image,
                short_text = news.ShortText,
                created_date = news.CreatedDate.ToString("dd-MM-yyyy HH:mm")
            }));
        }
    }
}
