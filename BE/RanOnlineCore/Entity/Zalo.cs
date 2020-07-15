using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class Zalo<T>
    {
        public int error { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
