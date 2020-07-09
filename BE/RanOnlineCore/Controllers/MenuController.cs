using Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RanOnlineCore.Action.MenuModel;
using RanOnlineCore.Framework;

namespace RanOnlineCore.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(IOptions<GlobalConfig> config) : base(config)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var action = new MenuGetAction();
            return this.MakeResult(action.Execute(CurrentObjectContext));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]CreateMenuAction action)
        {
            return this.MakeResult(action.Execute(CurrentObjectContext));
        }

        [HttpDelete]
        [AllowAnonymous]
        public IActionResult Delete([FromBody]DeleteMenuAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}