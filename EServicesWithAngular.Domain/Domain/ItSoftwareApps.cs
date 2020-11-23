using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Software_Apps")]
    public class ItSoftwareApps
    {
        public ItSoftwareApps()
        {
            ItSoftwareRequestItems = new HashSet<ItSoftwareRequestItems>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("CategoryID")]
        public int CategoryId { get; private set; }
        [Required]
        [StringLength(100)]
        public string AppName { get; private set; }
        public bool RequiresLicense { get; private set; }
        [Column("IsEA")]
        public bool IsEa { get; private set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("ItSoftwareApps")]
        public ItSoftwareCategory Category { get; private set; }
        [InverseProperty("App")]
        public ICollection<ItSoftwareRequestItems> ItSoftwareRequestItems { get; private set; }
    }
}
