using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    [Table("Users")]
    public partial class User : BaseEntity
    {
        [Key]
        public virtual long Id { get; set; }
        public virtual long? IngameId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ChaName { get; set; }
        public virtual long Point { get; set; }
        public virtual string Role { get; set; }
        public virtual IEnumerable<Payment> Payments { get; set; }
        public virtual IEnumerable<Donation> Donations { get; set; }
    }
}
