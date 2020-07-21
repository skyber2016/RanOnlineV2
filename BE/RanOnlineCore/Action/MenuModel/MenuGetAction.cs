using Dapper.FastCrud;
using Framework;
using PA.Caching;
using RanOnlineCore.Entity;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Linq;

namespace RanOnlineCore.Action.MenuModel
{
    public class MenuGetAction : CommandBase<IEnumerable<dynamic>>
    {
        private IEnumerable<dynamic> GetMenu(ObjectContext context)
        {
            var menus = context.Factory.Query("wp_postmeta").Where("meta_key", PostMetaType.Object_ID).Get<PostMeta>();
            var result = menus.Where(w =>
            {
                return w.Master[PostMetaType.Parent].meta_value == "0";
            }).Select(x =>
            {
                return new
                {
                    id = x.post_id,
                    name = x.Posts.post_title,
                    url = x.Master[PostMetaType.Url].meta_value ?? "#",
                    order = x.Posts.menu_order,
                    items =
                        menus
                        .Where(w => w.Master[PostMetaType.Parent].meta_value == x.post_id.ToString())
                        .Select(item =>
                        {
                            return new
                            {
                                id = item.post_id,
                                name = item.Posts.post_title,
                                order = item.Posts.menu_order,
                                url = item.Master[PostMetaType.Url].meta_value ?? "#",
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
            }, 5);
            return Success(result);
            
        }
    }
}
