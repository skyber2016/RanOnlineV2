using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class CardResult
    {
        public int trans_id { get; set; }
        public string request_id { get; set; }
        public int amount { get; set; }
        public object value { get; set; }
        public int declared_value { get; set; }
        public string telco { get; set; }
        public string serial { get; set; }
        public string code { get; set; }
        public int status { get; set; }
        public string message { get; set; }
    }
}
