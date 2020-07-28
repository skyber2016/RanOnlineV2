using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class AttackEntity
    {
        public string IP { get; set; }
        public int LoginPort { get; set; }
        public int GamePort { get; set; }
        public string Name { get; set; }
    }
}
