﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    [Table("Setting")]
    public partial class Setting
    {
        [Key]
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
    }
}
