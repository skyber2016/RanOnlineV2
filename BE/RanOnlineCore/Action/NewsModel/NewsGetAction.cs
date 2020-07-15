using Dapper.FastCrud;
using Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RanOnlineCore.Entity;
using System.Collections.Generic;
using System.Linq;
using ZaloCSharpSDK;
using ZaloDotNetSDK.entities;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetAction : CommandBase<dynamic>
    {
        public int? CurrentPage { get; set; } = 1;
        private int? PageSize { get; set; } = 5;


        private Medias GetNews(ObjectContext context)
        {
            JObject result = context.ZaloClient.getsliceArticle(this.CurrentPage.Value - 1, this.PageSize.Value, "normal");
            var data= result.ToObject<Zalo<Medias>>();
            if(data.error == 0)
            {
                return data.data;
            }
            throw new BadRequestException();
        }
        protected override void ValidateCore(ObjectContext context)
        {
            this.CurrentPage = this.CurrentPage ?? 1;
            this.PageSize = this.PageSize ?? 1;
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            var listNews = this.GetNews(context);
            //return Success(listNews.Select(news => new {
            //    id = news.Id,
            //    title = news.Title,
            //    image = news.Image,
            //    short_text = news.ShortText,
            //    created_date = news.CreatedDate.ToString("dd-MM-yyyy HH:mm"),
            //    url = $"/news/{news.Id}/{context.UrlFriend(news.Title)}"
            //}));
            return Success(listNews);
        }
    }
}
