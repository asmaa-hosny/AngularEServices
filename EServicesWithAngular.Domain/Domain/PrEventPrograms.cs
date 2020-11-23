using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_Programs")]
    public class PrEventPrograms
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("EventID")]
        public int EventId { get; private set; }
        [Column("ProgramID")]
        public int ProgramId { get; private set; }
        public string Notes { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? VisitStartDate { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? VisitEndDate { get; private set; }
        [StringLength(10)]
        public string VisitStartTime { get; private set; }
        [StringLength(10)]
        public string VisitEndTime { get; private set; }
        [StringLength(50)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }

        [ForeignKey("EventId")]
        [InverseProperty("PrEventPrograms")]
        public PrEvent Event { get; private set; }
        [ForeignKey("ProgramId")]
        [InverseProperty("PrEventPrograms")]
        public PrEventProgramType Program { get; private set; }
        [ForeignKey("Status")]
        [InverseProperty("PrEventPrograms")]
        public PrStatuses StatusNavigation { get; private set; }
    }
}
