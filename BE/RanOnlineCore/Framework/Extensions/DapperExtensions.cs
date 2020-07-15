using Dapper.FastCrud;
using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore
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
        public static IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T> IsDeletedFalse<T>(this IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T> builder)
        {
            return builder.Where($"IsDeleted = @isDeleted").WithParameters(new { isDeleted = false});
        }
        public static IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T> GetId<T>(this IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T> builder, long id)
        {
            return builder.IsDeletedFalse().Where($"Id = @id").WithParameters(new { id });
        }
        public static IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T> OrderByDesc<T>(this IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T> builder)
        {
            return builder.OrderBy($"CreatedDate DESC");
        }
        public static T IsDeletedFalse<T>(this object baseEntity)
        {
            if (baseEntity == null)
            {
                throw new NotFoundException();
            }
            var response = (BaseEntity)baseEntity;
            if (!response.IsDeleted)
            {
                return (T)baseEntity;
            }
            throw new NotFoundException();
        }
        public static IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Menu> ById(this IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<Menu> builder,long id)
        {
            return builder.Where($"Id = @id").WithParameters(new { id });
        }
    }
}
