using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("Core_Lookup_items")]
    public class CoreLookupItems
    {
        [Key]
        [Column("Lookup_Item_ID")]
        [StringLength(5)]
        public string LookupItemId { get; private set; }
        [Column("TextAR")]
        [StringLength(50)]
        public string TextAr { get; private set; }
        [Column("TextEN")]
        [StringLength(50)]
        public string TextEn { get; private set; }
    }
}
