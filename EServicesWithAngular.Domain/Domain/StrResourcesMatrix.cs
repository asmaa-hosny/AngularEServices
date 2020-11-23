using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("STR_ResourcesMatrix")]
    public class StrResourcesMatrix
    {
        public StrResourcesMatrix()
        {
            StrResourcesMatrixResources = new HashSet<StrResourcesMatrixResources>();
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
        [StringLength(1000)]
        public string Notes { get; private set; }
        public int TargetedDepartment { get; private set; }
        [Required]
        [StringLength(50)]
        public string ProjectName { get; private set; }

        [InverseProperty("Request")]
        public ICollection<StrResourcesMatrixResources> StrResourcesMatrixResources { get; private set; }
    }
}
