using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_Guests")]
    public class PrEventGuests
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("EventID")]
        public int? EventId { get; private set; }
        public bool? IsExternal { get; private set; }
        [StringLength(50)]
        public string Name { get; private set; }
        [StringLength(50)]
        public string Position { get; private set; }

        [ForeignKey("EventId")]
        [InverseProperty("PrEventGuests")]
        public PrEvent Event { get; private set; }
    }
}
