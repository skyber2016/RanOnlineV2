using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.MenuModel
{
    public class CreateMenuAction : CommandBase
    {
        public long? parentId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(parentId == null || name == null || url == null)
            {
                throw new BadRequestException();
            }
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            var menu = new Menu();
            menu.ParentId = this.parentId;
            menu.Name = this.name;
            menu.Url = this.url;
            context.RanMaster.Insert<Menu>(menu);
            return Success();
        }
    }
}
