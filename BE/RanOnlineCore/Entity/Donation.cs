using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    [Table("Donation")]
    public partial class Donation : BaseEntity
    {
        [Key]
        public virtual long Id { get; set; }
        [ForeignKey("User")]
        public virtual long UsersId { get; set; }
        public virtual string ChaName { get; set; }
        public virtual long Value { get; set; }
        public virtual int Type { get; set; }
        public virtual string Hash { get; set; }
        public virtual bool Status { get; set; }
        public virtual User User { get; set; }
    }
}
