//using Dapper.FastCrud;
//using Entity.RanMaster;
//using Entity.RanUser;
//using Entity.Response;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace Framework
//{
//    public class AuthorizeAttribute : ActionFilterAttribute
//    {
//        private static readonly Type allowAnonymousAttrType = typeof(AllowAnonymousAttribute);
//        private Type permissionAttr = typeof(PermisstionAttribute);

//        private User GetUser(ObjectContext context, long userId)
//        {
//            return context.RanMaster.Get<User>(new User { UserId = userId });
//        }
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            var controller = actionContext.ControllerContext.Controller as BaseController;
//            var context = controller.CurrentObjectContext;
//            try
//            {
//                if (Enumerable.Any<AllowAnonymousAttribute>((IEnumerable<AllowAnonymousAttribute>)actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>()))
//                {
//                    base.OnActionExecuting(actionContext);
//                    return;
//                }
//                void UnAuthorize()
//                {
//                    context.Logger.Error($"[{DateTime.Now.ToString("HH:mm:ss")}]-[{context.ClientIP}]-[AUTH FAILED]");
//                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//                }
//                IEnumerable<string> values;
//                actionContext.Request.Headers.TryGetValues("token", out values);
//                var tokenHeader = values?.FirstOrDefault();
//                if (tokenHeader == null)
//                {
//                    UnAuthorize();
//                    return;
//                }
//                var tokenDecrypt = context.Decrypt(tokenHeader);
//                var token = JsonConvert.DeserializeObject<AuthResponse>(tokenDecrypt);
//                if (DateTime.Now.Ticks > token.Expired)
//                {
//                    context.Logger.Error($"[{DateTime.Now.ToString("HH:mm:ss")}]-[{context.ClientIP}]-[EXPIRED]");
//                    UnAuthorize();
//                    return;
//                }
//                var user = this.GetUser(context, token.UserID);
//                if (user == null)
//                {
//                    UnAuthorize();
//                    return;
//                }
//                var role = actionContext.ActionDescriptor.GetCustomAttributes<PermisstionAttribute>().FirstOrDefault();
//                if (role == null)
//                {
//                    role = new PermisstionAttribute(Role.Admin);
//                }
//                var access = role.Role;
//                if (user.RoleId < (int)access)
//                {
//                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
//                    context.Logger.Error($"[{DateTime.Now.ToString("HH:mm:ss")}]-[{context.ClientIP}]-[FORBIDDEN]-[{actionContext.Request.Method}:{actionContext.Request.RequestUri.ToString()}]-[{JsonConvert.SerializeObject(actionContext.ActionDescriptor)}]");
//                    return;
//                }
//                else
//                {
//                    context.Logger.Trace($"[Auth]-[{DateTime.Now.ToString("HH:mm:ss")}]-[{context.ClientIP}]-[{user.IngameName}]-[LOGIN SUCCESS]");
//                    base.OnActionExecuting(actionContext);
//                }
//            }
//            catch (Exception ex)
//            {
//                context.Logger.Error($"[Auth]-[{DateTime.Now.ToString("HH:mm:ss")}]-[{context.ClientIP}]-[{ex.Message}]");
//                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//            }

//        }
//    }
//}
