using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_EmailGroup")]
    public class ItEmailGroup
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(50)]
        public string RefId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [StringLength(1000)]
        public string Notes { get; private set; }
        [Required]
        [StringLength(1000)]
        public string Justification { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmailName { get; private set; }
        public bool IsNeededForExternal { get; private set; }
    }
}
