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
        private IEnumerable<News> GetNewsFriend(ObjectContext context,long categoryId,long newsId)
        {
            return context.RanMaster.Find<News>(state => state
                .IsDeletedFalse()
                .Where($"News.CategoryId = @categoryId")
                .Where($"News.Id != @newsId")
                .WithParameters(new { categoryId, newsId })
                .OrderBy($"News.CreatedDate DESC")
                .Top(5)
                .Include<Category>(s => s.LeftOuterJoin())
                );
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {

            var news = this.GetNews(context);
            var newFriend = this.GetNewsFriend(context, news.CategoryId,news.Id);
            return Success(new
            {
                id = news.Id,
                title = news.Title,
                short_text = news.ShortText,
                created_date = news.CreatedDate.ToString("dd/MM/yyyy HH:mm"),
                author = news.Author,
                content = context.Base64Decode(news.Content.BodyText),
                friends = newFriend.Select(x => {
                    return new
                    {
                        id = x.Id,
                        title = x.Title,
                        category_name = x.Category.Name,
                        created_date = x.CreatedDate.ToString("dd/MM/yyyy HH:mm"),
                        url = $"/news/{x.Id}/{context.UrlFriend(x.Title)}"
                    };
                })
            });
        }
    }
}
