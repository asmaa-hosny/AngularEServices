using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Evaluation_DevelopmentNeeds")]
    public class HrEvaluationDevelopmentNeeds
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("EvaluationMasterID")]
        public int EvaluationMasterId { get; private set; }
        [Column("CompetencyID")]
        public int CompetencyId { get; private set; }
        [Required]
        [StringLength(50)]
        public string CompetencyText { get; private set; }
        [StringLength(500)]
        public string DevelopmentNature { get; private set; }
        [StringLength(500)]
        public string SuggestedTraining { get; private set; }

        [ForeignKey("EvaluationMasterId")]
        [InverseProperty("HrEvaluationDevelopmentNeeds")]
        public HrEvaluationEmpEvaluationMaster EvaluationMaster { get; private set; }
    }
}
