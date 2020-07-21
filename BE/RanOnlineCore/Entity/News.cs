using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class News
    {
        public string id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public int total_view { get; set; }
        public int total_share { get; set; }
        public long create_date { get; set; }
        public long update_date { get; set; }
        public string thumb { get; set; }
        public string link_view { get; set; }
    }
}
