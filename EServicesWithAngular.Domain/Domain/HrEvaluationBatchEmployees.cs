using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Evaluation_BatchEmployees")]
    public class HrEvaluationBatchEmployees
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("BatchID")]
        public int BatchId { get; private set; }
        [Column("EvaluationID")]
        public int EvaluationId { get; private set; }

        [ForeignKey("BatchId")]
        [InverseProperty("HrEvaluationBatchEmployees")]
        public HrEvaluationBatchMaster Batch { get; private set; }
        [ForeignKey("EvaluationId")]
        [InverseProperty("HrEvaluationBatchEmployees")]
        public HrEvaluationEmpEvaluationMaster Evaluation { get; private set; }
    }
}
