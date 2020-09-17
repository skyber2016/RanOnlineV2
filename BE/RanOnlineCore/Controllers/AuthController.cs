using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.AuthAction;
using RanOnlineCore.Framework;

namespace RanOnlineCore.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IOptions<GlobalConfig> config) : base(config)
        {
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]LoginAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegisterAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}