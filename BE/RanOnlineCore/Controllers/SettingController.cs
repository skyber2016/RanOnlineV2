using Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.SettingModel;
using RanOnlineCore.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Controllers
{
    public class SettingController : BaseController
    {
        public SettingController(IOptions<GlobalConfig> config) : base(config)
        {
        }

        [AllowAnonymous]
        public IActionResult Get([FromQuery]SettingGetAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}
