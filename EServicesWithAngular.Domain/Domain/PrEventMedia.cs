using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_Media")]
    public class PrEventMedia
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("EventID")]
        public int EventId { get; private set; }
        public int MediaType { get; private set; }
        public string Notes { get; private set; }
        [StringLength(50)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }

        [ForeignKey("EventId")]
        [InverseProperty("PrEventMedia")]
        public PrEvent Event { get; private set; }
        [ForeignKey("MediaType")]
        [InverseProperty("PrEventMedia")]
        public PrEventMediaType MediaTypeNavigation { get; private set; }
        [ForeignKey("Status")]
        [InverseProperty("PrEventMedia")]
        public PrStatuses StatusNavigation { get; private set; }
    }
}
