using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IAEA_Deliverables")]
    public class IaeaDeliverables
    {
        [Column("id")]
        public int Id { get; private set; }
        public int? ConditionId { get; private set; }
        public string Description { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; private set; }
        [Column("KPI")]
        public string Kpi { get; private set; }
        [StringLength(100)]
        public string Owner { get; private set; }
        [StringLength(50)]
        public string WorkingHours { get; private set; }

        [ForeignKey("ConditionId")]
        [InverseProperty("IaeaDeliverables")]
        public IaeaConditions Condition { get; private set; }
    }
}
