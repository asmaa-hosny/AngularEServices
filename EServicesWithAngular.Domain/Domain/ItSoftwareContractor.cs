using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Software_Contractor")]
    public class ItSoftwareContractor
    {
        public ItSoftwareContractor()
        {
            ItSoftware = new HashSet<ItSoftware>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [StringLength(500)]
        public string ContractorName { get; private set; }
        [Required]
        [StringLength(500)]
        public string ContractorProject { get; private set; }
        [Required]
        [StringLength(500)]
        public string ContractorEmail { get; private set; }
        [Required]
        [StringLength(500)]
        public string ContractorCompany { get; private set; }
        [Required]
        [StringLength(500)]
        public string ContractorPhone { get; private set; }

        [InverseProperty("Contractor")]
        public ICollection<ItSoftware> ItSoftware { get; private set; }
    }
}
