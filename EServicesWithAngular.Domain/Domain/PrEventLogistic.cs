using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_Logistic")]
    public class PrEventLogistic
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("EventID")]
        public int EventId { get; private set; }
        [Column("LogisticID")]
        public int LogisticId { get; private set; }
        [StringLength(50)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }
        [StringLength(50)]
        public string OtherLogistic { get; private set; }

        [ForeignKey("EventId")]
        [InverseProperty("PrEventLogistic")]
        public PrEvent Event { get; private set; }
        [ForeignKey("LogisticId")]
        [InverseProperty("PrEventLogistic")]
        public PrEventLogisticType Logistic { get; private set; }
        [ForeignKey("Status")]
        [InverseProperty("PrEventLogistic")]
        public PrStatuses StatusNavigation { get; private set; }
    }
}
