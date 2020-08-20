using Framework;
using Microsoft.AspNetCore.Mvc.Filters;
using PA.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RanOnlineCore.Framework.Attributes
{
    public class RateLimit : ActionFilterAttribute
    {
        public int min { get; set; }
        public int count { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as BaseController;
            var _context = controller.CurrentObjectContext;
            var ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (_context.cache.IsSet(ip.ToString()))
            {
                var count = _context.cache.Get<int>(ip);
                if(count >= this.count)
                {
                    context.Result = controller.BadRequest("Bạn đang thao tác quá nhanh, vui lòng thử lại sau!");
                    return;
                }
                else
                {
                    _context.cache.Remove(ip);
                    _context.cache.Set(ip, count + 1,min);
                    base.OnActionExecuting(context);
                }
            }
            else
            {
                _context.cache.Set(ip, 1, min);
                base.OnActionExecuting(context);
            }
        }
    }
}
