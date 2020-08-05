using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    [Table("Card")]
    public class Card
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Seri { get; set; }
        public string Telco { get; set; }
        public string Username { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
