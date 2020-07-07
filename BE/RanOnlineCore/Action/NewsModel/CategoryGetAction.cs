using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.NewsModel
{
    public class CategoryGetAction : CommandBase<IEnumerable<dynamic>>
    {
        private IEnumerable<Category> GetCategories(ObjectContext context)
        {
            return context.RanMaster.Find<Category>(state => 
                state.IsDeletedFalse()
                );
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {

            var categories = this.GetCategories(context);
            var data = categories.Select(cate =>
            {
                return new
                {
                    id = cate.Id,
                    name = cate.Name
                };
            });
            return Success(data);
        }
    }
}
