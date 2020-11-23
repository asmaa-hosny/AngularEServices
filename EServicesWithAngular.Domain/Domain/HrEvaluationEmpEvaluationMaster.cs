using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Evaluation_EmpEvaluationMaster")]
    public class HrEvaluationEmpEvaluationMaster
    {
        public HrEvaluationEmpEvaluationMaster()
        {
            HrEvaluationBatchEmployees = new HashSet<HrEvaluationBatchEmployees>();
            HrEvaluationDevelopmentNeeds = new HashSet<HrEvaluationDevelopmentNeeds>();
            HrEvaluationEmpEvaluationLine = new HashSet<HrEvaluationEmpEvaluationLine>();
            HrEvaluationTrainingNeeds = new HashSet<HrEvaluationTrainingNeeds>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("EvaluationTemplateID")]
        public long EvaluationTemplateId { get; private set; }
        [Required]
        [StringLength(500)]
        public string EmployeeName { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Column("EmployeeID")]
        public long EmployeeId { get; private set; }
        [Required]
        [StringLength(500)]
        public string EmployeeDepartment { get; private set; }
        [Required]
        [StringLength(500)]
        public string EmployeeManager { get; private set; }
        [Required]
        [StringLength(500)]
        public string EmployeeDepartmentManager { get; private set; }
        [StringLength(500)]
        public string EmployeeSector { get; private set; }
        [Required]
        [StringLength(500)]
        public string EmployeeJobTitle { get; private set; }
        [Required]
        [StringLength(500)]
        public string Evaluator { get; private set; }
        public bool IsLocked { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; private set; }
        public double? TotalScore { get; private set; }
        [StringLength(50)]
        public string TotalScoreText { get; private set; }
        public bool? Notified { get; private set; }

        [InverseProperty("Evaluation")]
        public ICollection<HrEvaluationBatchEmployees> HrEvaluationBatchEmployees { get; private set; }
        [InverseProperty("EvaluationMaster")]
        public ICollection<HrEvaluationDevelopmentNeeds> HrEvaluationDevelopmentNeeds { get; private set; }
        [InverseProperty("Master")]
        public ICollection<HrEvaluationEmpEvaluationLine> HrEvaluationEmpEvaluationLine { get; private set; }
        [InverseProperty("EvaluationMaster")]
        public ICollection<HrEvaluationTrainingNeeds> HrEvaluationTrainingNeeds { get; private set; }
    }
}
