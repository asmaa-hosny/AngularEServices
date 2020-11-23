using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_EventLocations")]
    public class PrEventEventLocations
    {
        public PrEventEventLocations()
        {
            PrEvent = new HashSet<PrEvent>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("LocationAR")]
        [StringLength(50)]
        public string LocationAr { get; private set; }
        [Column("LocationEN")]
        [StringLength(50)]
        public string LocationEn { get; private set; }

        [InverseProperty("EventLocationNavigation")]
        public ICollection<PrEvent> PrEvent { get; private set; }
    }
}
