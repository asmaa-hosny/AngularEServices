using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IAEA_Issues")]
    public class IaeaIssues
    {
        public IaeaIssues()
        {
            IaeaPhases = new HashSet<IaeaPhases>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("description")]
        public string Description { get; private set; }

        [InverseProperty("Issue")]
        public ICollection<IaeaPhases> IaeaPhases { get; private set; }
    }
}
