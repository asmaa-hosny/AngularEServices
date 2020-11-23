using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events")]
    public class PublicRelationsEvents
    {
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(14)]
        public string RefId { get; private set; }
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [StringLength(50)]
        public string EventType { get; private set; }
        [StringLength(50)]
        public string EventName { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? EventStartDate { get; private set; }
        [StringLength(50)]
        public string EventStartTime { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? EventEndDate { get; private set; }
        [StringLength(50)]
        public string EventEndTime { get; private set; }
        [StringLength(50)]
        public string EventLocation { get; private set; }
        public int? NumOfAttendees { get; private set; }
        [StringLength(50)]
        public string OtherNeeds { get; private set; }
    }
}
