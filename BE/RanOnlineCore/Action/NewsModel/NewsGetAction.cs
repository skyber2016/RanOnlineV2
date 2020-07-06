using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using RanOnlineCore.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetAction : CommandBase<IEnumerable<dynamic>>
    {
        private IEnumerable<Category> GetCategories(ObjectContext context)
        {
            return context.RanMaster.Find<Category>(state => state.IsDeletedFalse());
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            var data = this.GetCategories(context).Select(cate =>
            {
                return new
                {
                    id = cate.Id,
                    name = cate.Name,
                    items = cate.News.Select(news =>
                    {
                        return new
                        {
                            id = news.Id,
                            title = news.Title,
                            short_text = news.ShortText,
                            image = news.Image,
                            author = news.Author
                        };
                    })
                };
            });
            return Success(data);
        }
    }
}
