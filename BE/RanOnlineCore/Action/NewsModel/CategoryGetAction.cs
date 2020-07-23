using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using SqlKata.Execution;
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
            return context.Factory.Query("wp_terms").Get<Category>();
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {

            var categories = this.GetCategories(context);
            var data = categories.Select(cate =>
            {
                return new
                {
                    id = cate.term_id,
                    name = cate.name
                };
            });
            return Success(data);
        }
    }
}
