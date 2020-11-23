using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_MediaType")]
    public class PrEventMediaType
    {
        public PrEventMediaType()
        {
            PrEventMedia = new HashSet<PrEventMedia>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string MediaType { get; private set; }
        [Column("MediaTypeAR")]
        [StringLength(50)]
        public string MediaTypeAr { get; private set; }

        [InverseProperty("MediaTypeNavigation")]
        public ICollection<PrEventMedia> PrEventMedia { get; private set; }
    }
}
