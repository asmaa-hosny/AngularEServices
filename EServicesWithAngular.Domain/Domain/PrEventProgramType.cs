using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event_ProgramType")]
    public class PrEventProgramType
    {
        public PrEventProgramType()
        {
            PrEventPrograms = new HashSet<PrEventPrograms>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string ProgramType { get; private set; }
        [Column("ProgramTypeAR")]
        [StringLength(50)]
        public string ProgramTypeAr { get; private set; }

        [InverseProperty("Program")]
        public ICollection<PrEventPrograms> PrEventPrograms { get; private set; }
    }
}
