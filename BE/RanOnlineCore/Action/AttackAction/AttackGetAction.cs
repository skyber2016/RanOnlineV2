using Framework;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.AttackAction
{
    public class AttackGetAction : CommandBase<dynamic>
    {
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(new {
                request_id = context.RequestId,
                time_start = ObjectContext.TimeStart.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                messages = ObjectContext.Messages
            });
        }
    }
}
