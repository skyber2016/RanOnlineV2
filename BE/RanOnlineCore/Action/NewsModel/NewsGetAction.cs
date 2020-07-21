using Dapper.FastCrud;
using Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using ZaloCSharpSDK;
using ZaloDotNetSDK.entities;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetAction : CommandBase<IEnumerable<dynamic>>
    {
        public int? CurrentPage { get; set; } = 1;
        private int? PageSize { get; set; } = 5;


        private List<News> GetNews(ObjectContext context)
        {
            JObject result = context.ZaloClient.getsliceArticle(this.CurrentPage.Value - 1, this.PageSize.Value, "normal");
            var data= result.ToObject<Zalo<Medias>>();
            if(data.error == 0)
            {
                return data.data.medias;
            }
            return new List<News>();
        }
        protected override void ValidateCore(ObjectContext context)
        {
            this.CurrentPage = this.CurrentPage ?? 1;
            this.PageSize = this.PageSize ?? 1;
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            var listNews = this.GetNews(context);
            return Success(listNews.Select(news => new
            {
                id = news.id,
                title = news.title,
                image = news.thumb,
                short_text = news.title,
                created_date = (new DateTime(news.create_date)).ToString("dd-MM-yyyy HH:mm"),
                url = $"/news/{news.id}/{context.UrlFriend(news.title)}"
            }));
        }
    }
}
