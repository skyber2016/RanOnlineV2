using Framework;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Framework.Attributes
{
    public class BlockDomainAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as BaseController;
            var host = context.HttpContext.Request.Host;
            var allowHost = new string[] { "localhost", "api.ranonlinevn.com" };
            if (host.HasValue)
            {
                if (allowHost.IndexOf(host.Host) < 0)
                {
                    context.Result = controller.BadRequest("access deny");
                    return;
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
