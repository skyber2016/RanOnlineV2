using RanOnlineCore.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class UserAuth
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime Expired { get; set; }
    }
}
