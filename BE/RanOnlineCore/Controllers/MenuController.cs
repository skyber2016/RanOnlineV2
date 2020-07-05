using Framework;
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
        public IActionResult Get()
        {
            var action = new MenuGetAction();
            return this.MakeResult(action.Execute(CurrentObjectContext));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateMenuAction action)
        {
            return this.MakeResult(action.Execute(CurrentObjectContext));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]DeleteMenuAction action)
        {
            return MakeResult(action.Execute(CurrentObjectContext));
        }
    }
}