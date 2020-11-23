using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Ink")]
    public class ItInk
    {
        public ItInk()
        {
            ItInkDetails = new HashSet<ItInkDetails>();
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
        [Column("RDate", TypeName = "datetime")]
        public DateTime? Rdate { get; private set; }

        [InverseProperty("Request")]
        public ICollection<ItInkDetails> ItInkDetails { get; private set; }
    }
}
