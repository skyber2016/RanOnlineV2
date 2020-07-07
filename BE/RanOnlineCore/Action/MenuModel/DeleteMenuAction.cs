using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RanOnlineCore.Action.MenuModel
{
    public class DeleteMenuAction : CommandBase
    {
        public long? Id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.Id == null)
            {
                throw new BadRequestException();
            }
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            var menu = context.RanMaster.Find<Menu>(state => state.IsDeletedFalse().ById(this.Id.Value)).FirstOrDefault();
            if(menu == null)
            {
                throw new NotFoundException();
            }
            menu.IsDeleted = true;
            context.RanMaster.Update(menu);
            return Success();
        }
    }
}
