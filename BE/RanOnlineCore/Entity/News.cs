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

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public virtual string Title { get; set; }

        [Required]
        public virtual long CategoryId { get; set; }

        [Required]
        public virtual string Author { get; set; }

        [Required]
        public virtual string ShortText { get; set; }

        [Required]
        public virtual string Image { get; set; }

        [Required]
        public virtual long ContentId { get; set; }

        [ForeignKey("ContentId")]
        public virtual Content Content { get; set; }
    }
}
