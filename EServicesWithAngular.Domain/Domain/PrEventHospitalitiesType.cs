using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_HospitalitiesType")]
    public class PrEventHospitalitiesType
    {
        public PrEventHospitalitiesType()
        {
            PrEventHospitalities = new HashSet<PrEventHospitalities>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string HospitalitiesType { get; private set; }
        [Column("HospitalitiesTypeAR")]
        [StringLength(50)]
        public string HospitalitiesTypeAr { get; private set; }
        [Column("disabled")]
        public bool? Disabled { get; private set; }

        [InverseProperty("HospitalitiesNavigation")]
        public ICollection<PrEventHospitalities> PrEventHospitalities { get; private set; }
    }
}
