using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_AirportRec")]
    public class PublicRelationsEventsAirportRec
    {
        [Required]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string FlightNo { get; private set; }
        [StringLength(50)]
        public string CarrierLines { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? ArrivalDate { get; private set; }
        [StringLength(50)]
        public string ArrivalTime { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? DepartureDate { get; private set; }
        [StringLength(50)]
        public string DepartureTime { get; private set; }
        [StringLength(50)]
        public string PersonName { get; private set; }
        [StringLength(50)]
        public string PersonPosition { get; private set; }
        public int? CompanionsCount { get; private set; }
        [StringLength(500)]
        public string Notes { get; private set; }
    }
}
