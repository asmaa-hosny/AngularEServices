using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_Needs")]
    public class PublicRelationsEventsNeeds
    {
        [Required]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("Need_id")]
        [StringLength(50)]
        public string NeedId { get; private set; }
        [StringLength(50)]
        public string Details { get; private set; }
    }
}
