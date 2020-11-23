using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IAEA_Conditions")]
    public class IaeaConditions
    {
        public IaeaConditions()
        {
            IaeaDeliverables = new HashSet<IaeaDeliverables>();
        }

        [Column("id")]
        public int Id { get; private set; }
        public int? PhaseId { get; private set; }
        [StringLength(100)]
        public string EmployeeEmail { get; private set; }
        [StringLength(500)]
        public string Summery { get; private set; }
        [StringLength(500)]
        public string Example { get; private set; }
        [StringLength(50)]
        public string CompletionPercentage { get; private set; }
        [Column("IAEAObs")]
        [StringLength(500)]
        public string Iaeaobs { get; private set; }

        [ForeignKey("PhaseId")]
        [InverseProperty("IaeaConditions")]
        public IaeaPhases Phase { get; private set; }
        [InverseProperty("Condition")]
        public ICollection<IaeaDeliverables> IaeaDeliverables { get; private set; }
    }
}
