using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PublicRelations_Events_AssociatedProgramsList")]
    public class PublicRelationsEventsAssociatedProgramsList
    {
        [Column("id")]
        [StringLength(50)]
        public string Id { get; private set; }
        [Column("AssociatedProgram_AR")]
        [StringLength(50)]
        public string AssociatedProgramAr { get; private set; }
        [Column("AssociatedProgram_EN")]
        [StringLength(50)]
        public string AssociatedProgramEn { get; private set; }
    }
}
