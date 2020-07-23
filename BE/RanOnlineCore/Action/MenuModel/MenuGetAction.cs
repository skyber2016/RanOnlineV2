using Dapper;
using Dapper.FastCrud;
using Framework;
using PA.Caching;
using RanOnlineCore.Entity;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanOnlineCore.Action.MenuModel
{
    public class MenuGetAction : CommandBase<IEnumerable<dynamic>>
    {
        private IEnumerable<dynamic> GetMenu(ObjectContext context)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select wp_posts.ID as Id,wp_posts.post_title as Title, parent.meta_value as ParentId, meta_url.meta_value as url, wp_posts.menu_order as MenuOrder ");
            builder.Append("from wp_posts ");
            builder.Append("left join wp_postmeta as parent on parent.post_id = wp_posts.ID and parent.meta_key = '_menu_item_menu_item_parent' ");
            builder.Append("left join wp_postmeta as meta_url on meta_url.post_id = wp_posts.ID and meta_url.meta_key = '_menu_item_url' ");
            builder.Append("where wp_posts.post_type = 'nav_menu_item' and wp_posts.post_status = 'publish'; ");
            var menus = context.RanMaster.Query<DTOPosts>(builder.ToString());
            //var menus = context.Factory.Query("wp_postmeta").Where("meta_key", PostMetaType.Object_ID).Get<PostMeta>();
            var result = menus.Where(w =>
            {
                return w.ParentId == 0;
            }).Select(x =>
            {
                return new
                {
                    id = x.Id,
                    name = x.Title,
                    url = x.Url ?? "#",
                    order = x.MenuOrder,
                    items =
                        menus
                        .Where(w => w.ParentId == x.Id)
                        .Select(item =>
                        {
                            return new
                            {
                                id = item.Id,
                                name = item.Title,
                                order = item.MenuOrder,
                                url = item.Url ?? "#",
                            };
                        }).OrderBy(item => item.order)
                };
            }).OrderBy(item => item.order);
            return result;
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            var result = context.cache.GetOrSet<IEnumerable<dynamic>>("cache_menu", () =>
            {
                return this.GetMenu(context);
            }, 1);
            return Success(result);
            
        }
    }
}
