using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_Hospitalities")]
    public class PrEventHospitalities
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("EventID")]
        public int EventId { get; private set; }
        public int? NoOfAttendees { get; private set; }
        [StringLength(10)]
        public string BreakTime { get; private set; }
        public int? Hospitalities { get; private set; }
        [StringLength(50)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }
        [StringLength(50)]
        public string OtherHospitalities { get; private set; }

        [ForeignKey("EventId")]
        [InverseProperty("PrEventHospitalities")]
        public PrEvent Event { get; private set; }
        [ForeignKey("Hospitalities")]
        [InverseProperty("PrEventHospitalities")]
        public PrEventHospitalitiesType HospitalitiesNavigation { get; private set; }
        [ForeignKey("Status")]
        [InverseProperty("PrEventHospitalities")]
        public PrStatuses StatusNavigation { get; private set; }
    }
}
