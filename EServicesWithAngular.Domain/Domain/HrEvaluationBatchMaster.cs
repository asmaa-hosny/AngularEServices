using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Evaluation_BatchMaster")]
    public class HrEvaluationBatchMaster
    {
        public HrEvaluationBatchMaster()
        {
            HrEvaluationBatchEmployees = new HashSet<HrEvaluationBatchEmployees>();
            HrEvaluationBatchRelationsDestinationBatchNavigation = new HashSet<HrEvaluationBatchRelations>();
            HrEvaluationBatchRelationsSourceBatchNavigation = new HashSet<HrEvaluationBatchRelations>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [StringLength(500)]
        public string BatchName { get; private set; }
        [Required]
        [StringLength(500)]
        public string BatchCreator { get; private set; }
        [Required]
        [StringLength(500)]
        public string Responsible { get; private set; }
        [StringLength(50)]
        public string Status { get; private set; }
        [StringLength(500)]
        public string Comment { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActionDate { get; private set; }

        [InverseProperty("Batch")]
        public ICollection<HrEvaluationBatchEmployees> HrEvaluationBatchEmployees { get; private set; }
        [InverseProperty("DestinationBatchNavigation")]
        public ICollection<HrEvaluationBatchRelations> HrEvaluationBatchRelationsDestinationBatchNavigation { get; private set; }
        [InverseProperty("SourceBatchNavigation")]
        public ICollection<HrEvaluationBatchRelations> HrEvaluationBatchRelationsSourceBatchNavigation { get; private set; }
    }
}
