using Dapper;
using Framework;
using Framework.Extensions;
using RanOnlineCore.Entity;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanOnlineCore.Action.NewsModel
{
    public class NewsGetContentAction : CommandBase<dynamic>
    {
        public string Id { get; set; }
        private Posts GetNews(ObjectContext context)
        {
            var data = context.Factory.Query("wp_posts").Where("ID", this.Id).FirstOrDefault<Posts>();
            return data;
        }
        private IEnumerable<Term> GetCategory(ObjectContext context)
        {
            return context.RanMaster.Query<Term>($"select wp_terms.* from wp_term_relationships left join wp_terms on wp_terms.term_id = wp_term_relationships.term_taxonomy_id where object_id = {this.Id} ");
        }
        private IEnumerable<PostFriend> GetNewsFriend(ObjectContext context)
        {
            var category = this.GetCategory(context);
            var categoryId = category.Select(x => x.term_id);
            var listId = string.Join(',', categoryId);
            var builder = new StringBuilder();
            
            builder.Append("select wp_term_relationships.object_id,wp_terms.name as category_name,wp_posts.post_title, wp_posts.post_date, wp_posts.post_name ");
            builder.Append("from wp_term_relationships ");
            builder.Append("left join wp_terms on wp_terms.term_id = wp_term_relationships.term_taxonomy_id ");
            builder.Append("left join wp_posts on wp_posts.ID = wp_term_relationships.object_id ");
            builder.Append($"where wp_term_relationships.term_taxonomy_id IN({listId}) and wp_term_relationships.object_id != {this.Id} ");
            builder.Append($"group by wp_term_relationships.object_id  ");
            builder.Append($"LIMIT 5 ");
            
            return context.RanMaster.Query<PostFriend>(builder.ToString());
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {

            var news = this.GetNews(context);
            if(news == null)
            {
                throw new NotFoundException();
            }
            var newFriend = this.GetNewsFriend(context);
            return Success(new
            {
                id = news.ID,
                title = news.post_title,
                short_text = news.post_excerpt,
                created_date = news.post_modified.ToString("dd/MM/yyyy HH:mm"),
                author = news.post_author,
                content = news.post_content,
                friends = newFriend.Select(x=>
                {
                    return new
                    {
                        id = x.object_id,
                        title = x.post_title,
                        created_date = x.post_date.ToString("dd-MM-yyyy HH:mm"),
                        category_name = x.category_name,
                        url = $"home/news/{x.object_id}/{x.post_name}"
                    };
                })
            });
        }
    }
}
