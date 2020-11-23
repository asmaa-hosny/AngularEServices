using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_EventTypesList")]
    public class PublicRelationsEventsEventTypesList
    {
        [Column("id")]
        [StringLength(50)]
        public string Id { get; private set; }
        [Column("EventType_AR")]
        [StringLength(50)]
        public string EventTypeAr { get; private set; }
        [Column("EventType_EN")]
        [StringLength(50)]
        public string EventTypeEn { get; private set; }
    }
}
