using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.AttackAction;
using RanOnlineCore.Framework;

namespace RanOnlineCore.Controllers
{
    public class AttackController : BaseController
    {
        public AttackController(IOptions<GlobalConfig> config) : base(config)
        {
        }
        [AllowAnonymous]
        public IActionResult Get([FromQuery]AttackGetAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
        [AllowAnonymous]
        [Route("Element")]
        public IActionResult Element([FromQuery]AttackElementAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}