using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    [Table("Payment")]
    public partial class Payment :BaseEntity
    {
        [Key]
        public virtual long Id { get; set; }
        public virtual long ItemId { get; set; }
        public virtual long Price { get; set; }
        [ForeignKey("User")]
        public virtual long UsersId { get; set; }
        public virtual long FinalPoint { get; set; }
        public virtual long CurrentPoint { get; set; }
        public virtual User User { get; set; }
    }
}
