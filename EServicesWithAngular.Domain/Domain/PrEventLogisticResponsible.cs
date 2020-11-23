using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_Logistic_Responsible")]
    public class PrEventLogisticResponsible
    {
        public PrEventLogisticResponsible()
        {
            PrEventLogisticType = new HashSet<PrEventLogisticType>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("ResponsibleAR")]
        [StringLength(50)]
        public string ResponsibleAr { get; private set; }
        [StringLength(50)]
        public string Responsible { get; private set; }

        [InverseProperty("Responsible")]
        public ICollection<PrEventLogisticType> PrEventLogisticType { get; private set; }
    }
}
