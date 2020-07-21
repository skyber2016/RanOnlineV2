using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.NewsModel;
using RanOnlineCore.Framework;

namespace RanOnlineCore.Controllers
{
    public class NewsController : BaseController
    {
        public NewsController(IOptions<GlobalConfig> config) : base(config)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery]NewsGetAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("detail")]
        public IActionResult GetById([FromQuery]NewsGetContentAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
        
    }
}