using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Software_Category")]
    public class ItSoftwareCategory
    {
        public ItSoftwareCategory()
        {
            ItSoftwareApps = new HashSet<ItSoftwareApps>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("CategoryNameAR")]
        [StringLength(50)]
        public string CategoryNameAr { get; private set; }
        [Required]
        [Column("CategoryNameEN")]
        [StringLength(50)]
        public string CategoryNameEn { get; private set; }

        [InverseProperty("Category")]
        public ICollection<ItSoftwareApps> ItSoftwareApps { get; private set; }
    }
}
