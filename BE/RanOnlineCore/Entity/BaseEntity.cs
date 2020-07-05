using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.IsDeleted = false;
            this.CreatedBy = "system";
            this.CreatedDate = DateTime.Now;
            this.UpdatedBy = "system";
            this.UpdatedDate = DateTime.Now;
        }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual string CreatedBy { get; set; }
    }
}
