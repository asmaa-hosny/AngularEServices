using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_GiftsList")]
    public class PublicRelationsEventsGiftsList
    {
        [Column("id")]
        [StringLength(50)]
        public string Id { get; private set; }
        [Required]
        [Column("Gift_AR")]
        [StringLength(50)]
        public string GiftAr { get; private set; }
        [Required]
        [Column("Gift_EN")]
        [StringLength(50)]
        public string GiftEn { get; private set; }
    }
}
