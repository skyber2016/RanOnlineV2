//using Framework;
//using Newtonsoft.Json;
//using System;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//public class LoggerAttribute : ActionFilterAttribute
//{
//    public override void OnActionExecuting(HttpActionContext actionContext)
//    {
//        var controller = actionContext.ControllerContext.Controller as BaseController;
//        var context = controller.CurrentObjectContext;
//        context.Logger.Trace($"[{DateTime.Now.ToString("HH:mm:ss")}]-[{context.ClientIP}]-{context.CurrentUser?.UserName}-{controller.Url.Request.Method.ToString()}:{controller.Url.Request.RequestUri}-{JsonConvert.SerializeObject(actionContext.ActionArguments)}");
//    }
//}