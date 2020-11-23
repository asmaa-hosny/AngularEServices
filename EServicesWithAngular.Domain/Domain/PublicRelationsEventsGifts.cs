using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_Gifts")]
    public class PublicRelationsEventsGifts
    {
        [Required]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("Gift_id")]
        [StringLength(50)]
        public string GiftId { get; private set; }
    }
}
