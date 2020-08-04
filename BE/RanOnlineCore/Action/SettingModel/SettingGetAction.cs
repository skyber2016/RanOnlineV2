using Framework;
using RanOnlineCore.Entity;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.SettingModel
{
    public class SettingGetAction : CommandBase<dynamic>
    {
        private IEnumerable<AdminSetting> GetSetting(ObjectContext context)
        {
            return context.Factory.Query("admin_setting").Get<AdminSetting>();
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            var settings = this.GetSetting(context);
            var dic = new Dictionary<string, string>();
            foreach (var setting in settings)
            {
                dic[setting.setting_key] = setting.setting_value;
            }
            return Success(dic);
        }
    }
}
