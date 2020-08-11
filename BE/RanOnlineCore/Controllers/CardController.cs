﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.CardModel;
using RanOnlineCore.Framework;

namespace RanOnlineCore.Controllers
{
    public class CardController : BaseController
    {
        public CardController(IOptions<GlobalConfig> config) : base(config)
        {
        }

        [HttpPost]
        public IActionResult Post([FromBody]CardPostAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}