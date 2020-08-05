using Dapper.FastCrud;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using RanOnlineCore.Entity;
using RanOnlineCore.Framework;
using RanOnlineCore.Framework.Attributes;
using RanOnlineCore.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Framework
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        private static readonly Type allowAnonymousAttrType = typeof(AllowAnonymousAttribute);

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var controller = actionContext.Controller as BaseController;
            var context = controller.CurrentObjectContext;
            try
            {
                var controllerActionDescriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;
                if (controllerActionDescriptor != null)
                {
                    var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).FirstOrDefault(x=> x.GetType() == typeof(AllowAnonymousAttribute));
                    if(actionAttributes != null)
                    {
                        base.OnActionExecuting(actionContext);
                        return;
                    }
                }
                var header = actionContext.HttpContext.Request.Headers;
                var auth = "Authorization";
                var authorize = header.ContainsKey(auth);
                if (!authorize)
                {
                    throw new NoAuthorizeException();
                }
                string token = header[auth];
                if (token.StartsWith("Bearer"))
                {
                    token = token.Replace("Bearer ","");
                }
                UserAuth user = context.Decrypt<UserAuth>(token);
                if (user == null)
                {
                    throw new NoAuthorizeException();
                }
                context.User = user;
                base.OnActionExecuting(actionContext);
            }
            catch (UnauthorizedAccessException)
            {
                actionContext.Result = controller.Forbid();
                return;
            }
            catch (NoAuthorizeException)
            {
                actionContext.Result = controller.Unauthorized();
                return;
            }
            catch (Exception)
            {
                actionContext.Result = controller.BadRequest();
                return;
            }

        }
    }
}
