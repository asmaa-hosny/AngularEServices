using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Statuses")]
    public class PrStatuses
    {
        public PrStatuses()
        {
            PrEventHospitalities = new HashSet<PrEventHospitalities>();
            PrEventLogistic = new HashSet<PrEventLogistic>();
            PrEventMedia = new HashSet<PrEventMedia>();
            PrEventPrograms = new HashSet<PrEventPrograms>();
        }

        [Key]
        [StringLength(50)]
        public string Code { get; private set; }
        [Column("StatusAR")]
        [StringLength(50)]
        public string StatusAr { get; private set; }
        [Column("StatusEN")]
        [StringLength(50)]
        public string StatusEn { get; private set; }

        [InverseProperty("StatusNavigation")]
        public ICollection<PrEventHospitalities> PrEventHospitalities { get; private set; }
        [InverseProperty("StatusNavigation")]
        public ICollection<PrEventLogistic> PrEventLogistic { get; private set; }
        [InverseProperty("StatusNavigation")]
        public ICollection<PrEventMedia> PrEventMedia { get; private set; }
        [InverseProperty("StatusNavigation")]
        public ICollection<PrEventPrograms> PrEventPrograms { get; private set; }
    }
}
