using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.RankingModel;
using RanOnlineCore.Framework;

namespace RanOnlineCore.Controllers
{
    public class RankingController : BaseController
    {
        public RankingController(IOptions<GlobalConfig> config) : base(config)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery]GetRankingAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}