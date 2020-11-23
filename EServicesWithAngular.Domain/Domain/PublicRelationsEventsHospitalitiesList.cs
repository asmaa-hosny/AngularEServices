using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_HospitalitiesList")]
    public class PublicRelationsEventsHospitalitiesList
    {
        [Column("id")]
        [StringLength(50)]
        public string Id { get; private set; }
        [Column("Hospitality_AR")]
        [StringLength(50)]
        public string HospitalityAr { get; private set; }
        [Column("Hospitality_EN")]
        [StringLength(50)]
        public string HospitalityEn { get; private set; }
    }
}
