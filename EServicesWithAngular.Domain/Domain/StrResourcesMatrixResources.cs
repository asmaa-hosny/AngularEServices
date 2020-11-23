using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("STR_ResourcesMatrix_Resources")]
    public class StrResourcesMatrixResources
    {
        [Column("id")]
        public int Id { get; private set; }
        public int ApproverNodeId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; private set; }
        public int DaysPerWeek { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; private set; }
        [Required]
        [StringLength(1000)]
        public string Tasks { get; private set; }
        [StringLength(10)]
        public string Status { get; private set; }
        [Column("RequestID")]
        public int? RequestId { get; private set; }

        [ForeignKey("RequestId")]
        [InverseProperty("StrResourcesMatrixResources")]
        public StrResourcesMatrix Request { get; private set; }
    }
}
