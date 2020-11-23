using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_ServerAccess")]
    public class ItServerAccess
    {
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
        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? DateTo { get; private set; }
        [StringLength(1000)]
        public string Notes { get; private set; }
        [Required]
        [StringLength(1000)]
        public string Justification { get; private set; }
        [Required]
        [StringLength(50)]
        public string Username { get; private set; }
    }
}
