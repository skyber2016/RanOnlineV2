using Dapper.FastCrud;
using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Framework.Extensions
{
    public static class DapperExtensions
    {
        public static bool Update(this IDbConnection db, Menu data)
        {
            data.UpdatedDate = DateTime.Now;
            data.UpdatedBy = "system";
            // TODO: Get authen
            return db.Update<Menu>(data);
        }
        public static IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Menu> IsDeletedFalse(this IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Menu> builder)
        {
            return builder.Where($"IsDeleted = @isDeleted").WithParameters(new { isDeleted = false});
        }
        public static IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Category> IsDeletedFalse(this IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Category> builder)
        {
            return builder.Where($"IsDeleted = @isDeleted").WithParameters(new { isDeleted = false});
        }
        public static IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Menu> ById(this IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Menu> builder,long id)
        {
            return builder.Where($"Id = @id").WithParameters(new { id });
        }
    }
}
