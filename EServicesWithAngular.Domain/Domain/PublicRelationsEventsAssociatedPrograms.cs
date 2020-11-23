using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_AssociatedPrograms")]
    public class PublicRelationsEventsAssociatedPrograms
    {
        [Required]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("AssociatedProgram_id")]
        [StringLength(50)]
        public string AssociatedProgramId { get; private set; }
        [StringLength(50)]
        public string OtherProgram { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? ArrivalDate { get; private set; }
        [StringLength(50)]
        public string ArrivalTime { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? DepartureDate { get; private set; }
        [StringLength(50)]
        public string DepartureTime { get; private set; }
        [StringLength(50)]
        public string CoordinatorName { get; private set; }
        [StringLength(50)]
        public string CoordinatorNumber { get; private set; }
        [StringLength(50)]
        public string Notes { get; private set; }
        public int? NumOfVistors { get; private set; }
    }
}
