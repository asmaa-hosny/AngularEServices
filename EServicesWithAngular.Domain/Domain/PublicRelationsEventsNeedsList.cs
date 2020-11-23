using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_NeedsList")]
    public class PublicRelationsEventsNeedsList
    {
        [Column("id")]
        [StringLength(50)]
        public string Id { get; private set; }
        [Column("Need_AR")]
        [StringLength(50)]
        public string NeedAr { get; private set; }
        [Column("Need_EN")]
        [StringLength(50)]
        public string NeedEn { get; private set; }
    }
}
