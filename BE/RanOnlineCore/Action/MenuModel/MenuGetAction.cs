using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.MenuModel
{
    public class MenuGetAction : CommandBase<IEnumerable<dynamic>>
    {
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            var menus = context.RanMaster.Find<Menu>(state => state.IsDeletedFalse());
            return Success(menus.Where(x=>x.ParentId == null).Select(x => {
                return new
                {
                    id = x.Id,
                    name = x.Name,
                    items = menus.Where(w => w.ParentId == x.Id).Select(item =>
                    {
                        return new
                        {
                            id = item.Id,
                            name = item.Name,
                            url = item.Url
                        };
                    })
                };
            }));
        }
    }
}
