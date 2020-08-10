using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Framework
{
    public class GlobalConfig
    {
        public string RanMaster { get; set; }
        public string RanUser { get; set; }
        public string RanGame { get; set; }
        public string ZaloAccessToken { get; set; }
        public string RabbitHost { get; set; }
        public int RabbitPort { get; set; }
        public string RabbitUsername { get; set; }
        public string RabbitPassword { get; set; }
        public string WordPress { get; set; }
    }
}
