using Dapper;
using Framework;
using RanOnlineCore.Entity;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetAction : CommandBase<IEnumerable<dynamic>>
    {
        public int? CurrentPage { get; set; } = 1;
        private int? PageSize { get; set; } = 5;

        public int? CategoryId { get; set; }
        private IEnumerable<TermRelationship> GetCategories(ObjectContext context)
        {
            return context.Factory.Query("wp_term_relationships").Where("term_taxonomy_id", this.CategoryId).Get<TermRelationship>();
        }

        private IEnumerable<DTOGetPosts> GetNews(ObjectContext context)
        {
            var categories = this.GetCategories(context).Select(x=>x.object_id);
            var strCategories = string.Join(",", categories);
            var builder = new StringBuilder();
            builder.Append("select wp_posts.*, attachment.guid as Thumb from wp_posts ");
            builder.Append("left join wp_postmeta meta on meta.post_id = wp_posts.ID and meta.meta_key = '_thumbnail_id' ");
            builder.Append("left join wp_posts attachment on attachment.ID = meta.meta_value and attachment.post_type = 'attachment' ");
            builder.Append($"where wp_posts.post_type = 'post' and wp_posts.post_status = 'publish' and wp_posts.ID IN({strCategories}) ");
            builder.Append($"LIMIT {(this.CurrentPage - 1) * this.PageSize},{this.PageSize} ");
            var data = context.RanMaster.Query<DTOGetPosts>(builder.ToString());
            return data;
        }
        protected override void ValidateCore(ObjectContext context)
        {
            this.CurrentPage = this.CurrentPage ?? 1;
            this.PageSize = this.PageSize ?? 1;
            if(this.CategoryId == null)
            {
                throw new BadRequestException();
            }
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            var listNews = this.GetNews(context);
            return Success(listNews.Select(news => new
            {
                id = news.ID,
                title = news.post_title,
                image = news.Thumb,
                short_text = news.post_excerpt,
                created_date = news.post_modified.ToString("dd-MM-yyyy HH:mm"),
                url = $"/news/{news.ID}/{news.post_name}"
            }));
        }
    }
}
