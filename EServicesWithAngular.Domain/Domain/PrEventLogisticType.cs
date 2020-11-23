using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_LogisticType")]
    public class PrEventLogisticType
    {
        public PrEventLogisticType()
        {
            PrEventLogistic = new HashSet<PrEventLogistic>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("logisticType")]
        [StringLength(50)]
        public string LogisticType { get; private set; }
        [Column("logisticTypeAR")]
        [StringLength(50)]
        public string LogisticTypeAr { get; private set; }
        [Column("ResponsibleID")]
        public int? ResponsibleId { get; private set; }

        [ForeignKey("ResponsibleId")]
        [InverseProperty("PrEventLogisticType")]
        public PrEventLogisticResponsible Responsible { get; private set; }
        [InverseProperty("Logistic")]
        public ICollection<PrEventLogistic> PrEventLogistic { get; private set; }
    }
}
