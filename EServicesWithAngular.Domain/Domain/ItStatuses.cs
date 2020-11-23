using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Statuses")]
    public class ItStatuses
    {
        public ItStatuses()
        {
            ItInkDetails = new HashSet<ItInkDetails>();
            ItSoftwareRequestItems = new HashSet<ItSoftwareRequestItems>();
        }

        [Key]
        [StringLength(15)]
        public string Code { get; private set; }
        [Required]
        [Column("StatusTextAR")]
        [StringLength(50)]
        public string StatusTextAr { get; private set; }
        [Required]
        [Column("StatusTextEN")]
        [StringLength(50)]
        public string StatusTextEn { get; private set; }

        [InverseProperty("StatusNavigation")]
        public ICollection<ItInkDetails> ItInkDetails { get; private set; }
        [InverseProperty("StatusNavigation")]
        public ICollection<ItSoftwareRequestItems> ItSoftwareRequestItems { get; private set; }
    }
}
