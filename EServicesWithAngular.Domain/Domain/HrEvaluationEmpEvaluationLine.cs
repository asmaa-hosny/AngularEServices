using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Evaluation_EmpEvaluationLine")]
    public class HrEvaluationEmpEvaluationLine
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("MasterID")]
        public int MasterId { get; private set; }
        [Column("CompetencyID")]
        public long CompetencyId { get; private set; }
        public int Score { get; private set; }
        [StringLength(500)]
        public string Comments { get; private set; }

        [ForeignKey("MasterId")]
        [InverseProperty("HrEvaluationEmpEvaluationLine")]
        public HrEvaluationEmpEvaluationMaster Master { get; private set; }
    }
}
