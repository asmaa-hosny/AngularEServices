using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_EventType")]
    public class PrEventEventType
    {
        public PrEventEventType()
        {
            PrEvent = new HashSet<PrEvent>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string EventType { get; private set; }
        [Column("EventTypeAR")]
        [StringLength(50)]
        public string EventTypeAr { get; private set; }

        [InverseProperty("EventTypeNavigation")]
        public ICollection<PrEvent> PrEvent { get; private set; }
    }
}
