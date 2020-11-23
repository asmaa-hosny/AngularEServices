using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Probationary_Period")]
    public class HrProbationaryPeriod
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        public int? RefId { get; private set; }
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Column("RDate", TypeName = "datetime")]
        public DateTime? Rdate { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }
        [StringLength(50)]
        public string GeneralEvaluation { get; private set; }
        [Column("EContinuation")]
        [StringLength(50)]
        public string Econtinuation { get; private set; }
        [Column("HRRecomdation")]
        [StringLength(50)]
        public string Hrrecomdation { get; private set; }
        [Column("GBehaviour")]
        [StringLength(50)]
        public string Gbehaviour { get; private set; }
        [StringLength(50)]
        public string Commitment { get; private set; }
        [StringLength(50)]
        public string Learnable { get; private set; }
        [Column("CoWRelationships")]
        [StringLength(50)]
        public string CoWrelationships { get; private set; }
        [StringLength(50)]
        public string WorkSkills { get; private set; }
        [StringLength(50)]
        public string WorkQuality { get; private set; }
        [StringLength(50)]
        public string WorkInitiative { get; private set; }
        [StringLength(50)]
        public string Notes { get; private set; }
    }
}
