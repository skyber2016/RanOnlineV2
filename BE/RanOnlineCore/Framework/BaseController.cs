using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RanOnlineCore.Framework;
using System.Net;

namespace Framework
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class BaseController : ControllerBase
    {
        public BaseController(IOptions<GlobalConfig> config)
        {
            this.CreateObjectContext(config.Value);
        }
        public ObjectContext CurrentObjectContext { get; internal set; }
        protected virtual void CreateObjectContext(GlobalConfig config)
        {
            CurrentObjectContext = ObjectContext.CreateContext(this, config);

        }

        protected IActionResult MakeResult(Result obj)
        {
            var InternalMessage = "Server error";
            if (obj.IsSuccess)
            {
                return Ok();
            }
            switch (obj.Code)
            {
                case HttpStatusCode.NotFound:
                    return this.NotFound();
                case HttpStatusCode.InternalServerError:
                    return this.BadRequest(InternalMessage);
                case HttpStatusCode.Unauthorized:
                    return this.Unauthorized();
                default:
                    return this.BadRequest(obj.Message);
            }
        }
        protected IActionResult MakeResult<T>(Result<T> obj)
        {
            if (obj.IsSuccess)
            {
                return Ok(obj.Data);
            }
            return this.MakeResult((Result)obj);
        }
    }
}
