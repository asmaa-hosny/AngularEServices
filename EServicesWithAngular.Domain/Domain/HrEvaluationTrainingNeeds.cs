using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Evaluation_TrainingNeeds")]
    public class HrEvaluationTrainingNeeds
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
        public string WeaknessNature { get; private set; }
        [StringLength(500)]
        public string SuggestedTraining { get; private set; }

        [ForeignKey("EvaluationMasterId")]
        [InverseProperty("HrEvaluationTrainingNeeds")]
        public HrEvaluationEmpEvaluationMaster EvaluationMaster { get; private set; }
    }
}
