using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.NewsModel;
using RanOnlineCore.Framework;

namespace RanOnlineCore.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IOptions<GlobalConfig> config) : base(config)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var action = new CategoryGetAction();
            return MakeResult(action.Execute(CurrentObjectContext));
        }

        [HttpGet]
        [Route("news")]
        public IActionResult GetNewsByCategoryId([FromQuery]NewsGetAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}