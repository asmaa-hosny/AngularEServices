using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IAEA_Phases")]
    public class IaeaPhases
    {
        public IaeaPhases()
        {
            IaeaConditions = new HashSet<IaeaConditions>();
        }

        [Column("id")]
        public int Id { get; private set; }
        public int? IssueId { get; private set; }
        [Column("description")]
        public string Description { get; private set; }

        [ForeignKey("IssueId")]
        [InverseProperty("IaeaPhases")]
        public IaeaIssues Issue { get; private set; }
        [InverseProperty("Phase")]
        public ICollection<IaeaConditions> IaeaConditions { get; private set; }
    }
}
