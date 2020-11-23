using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Evaluation_BatchRelations")]
    public class HrEvaluationBatchRelations
    {
        [Column("id")]
        public int Id { get; private set; }
        public int SourceBatch { get; private set; }
        public int DestinationBatch { get; private set; }

        [ForeignKey("DestinationBatch")]
        [InverseProperty("HrEvaluationBatchRelationsDestinationBatchNavigation")]
        public HrEvaluationBatchMaster DestinationBatchNavigation { get; private set; }
        [ForeignKey("SourceBatch")]
        [InverseProperty("HrEvaluationBatchRelationsSourceBatchNavigation")]
        public HrEvaluationBatchMaster SourceBatchNavigation { get; private set; }
    }
}
