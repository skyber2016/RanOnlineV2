using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    [Table("News")]
    public class News : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
        [ForeignKey("Category")]
        public virtual long CategoryId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        [ForeignKey("Content")]
        public virtual long ContentId { get; set; }
        public virtual string ShortText { get; set; }
        public virtual string Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual Content Content { get; set; }
    }
}
