using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Software")]
    public class ItSoftware
    {
        public ItSoftware()
        {
            ItSoftwareRequestItems = new HashSet<ItSoftwareRequestItems>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(13)]
        public string RefId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Required]
        [StringLength(50)]
        public string RequestType { get; private set; }
        [StringLength(500)]
        public string OtherPrograms { get; private set; }
        [Required]
        [StringLength(500)]
        public string Justification { get; private set; }
        public int Qty { get; private set; }
        public int? ContractorId { get; private set; }
        [Column("RDate", TypeName = "datetime")]
        public DateTime? Rdate { get; private set; }

        [ForeignKey("ContractorId")]
        [InverseProperty("ItSoftware")]
        public ItSoftwareContractor Contractor { get; private set; }
        [InverseProperty("Request")]
        public ICollection<ItSoftwareRequestItems> ItSoftwareRequestItems { get; private set; }
    }
}
