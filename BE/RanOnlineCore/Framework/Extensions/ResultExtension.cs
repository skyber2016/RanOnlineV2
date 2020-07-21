using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extensions
{
    public static class ResultExtension
    {
        public static T ThrowIfFail<T>(this Result<T> result)
        {
            if (result.IsSuccess)
            {
                return result.Data;
            }
            throw new Exception(result.Message);
        }
        public static DateTime ToDateTime(this string value)
        {
            return Convert.ToDateTime(value);
        }
    }
}
