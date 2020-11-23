using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_Hospitalities")]
    public class PublicRelationsEventsHospitalities
    {
        [Required]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("Hospitality_id")]
        [StringLength(50)]
        public string HospitalityId { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? FromDate { get; private set; }
        [StringLength(50)]
        public string FromTime { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; private set; }
        [StringLength(50)]
        public string ToTime { get; private set; }
        public int? NumberOfInvitiees { get; private set; }
        [StringLength(50)]
        public string SuggestedLocation { get; private set; }
        [StringLength(50)]
        public string Notes { get; private set; }
    }
}
