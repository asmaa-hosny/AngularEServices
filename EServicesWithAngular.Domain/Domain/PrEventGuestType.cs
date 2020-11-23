using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_GuestType")]
    public class PrEventGuestType
    {
        public PrEventGuestType()
        {
            PrEvent = new HashSet<PrEvent>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string GuestType { get; private set; }
        [Column("GuestTypeAR")]
        [StringLength(50)]
        public string GuestTypeAr { get; private set; }

        [InverseProperty("GuestTypeNavigation")]
        public ICollection<PrEvent> PrEvent { get; private set; }
    }
}
