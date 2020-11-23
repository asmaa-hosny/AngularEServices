using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_BusinessCardRequest")]
    public class PrBusinessCardRequest
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("REF_ID")]
        [StringLength(50)]
        public string RefId { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Required]
        [Column("EmpNameAR")]
        [StringLength(50)]
        public string EmpNameAr { get; private set; }
        [Required]
        [Column("EmpNameEN")]
        [StringLength(50)]
        public string EmpNameEn { get; private set; }
        [Column("EmpEchoID")]
        public int EmpEchoId { get; private set; }
        [Required]
        [Column("PrefixAR")]
        [StringLength(50)]
        public string PrefixAr { get; private set; }
        [Required]
        [Column("PrefixEN")]
        [StringLength(50)]
        public string PrefixEn { get; private set; }
        [Required]
        [Column("PositionAR")]
        [StringLength(50)]
        public string PositionAr { get; private set; }
        [Required]
        [Column("PositionEN")]
        [StringLength(50)]
        public string PositionEn { get; private set; }
        [Required]
        [Column("DepartmentAR")]
        [StringLength(50)]
        public string DepartmentAr { get; private set; }
        [Required]
        [Column("DepartmentEN")]
        [StringLength(50)]
        public string DepartmentEn { get; private set; }
        [Column("SectorAR")]
        [StringLength(50)]
        public string SectorAr { get; private set; }
        [Column("SectorEN")]
        [StringLength(50)]
        public string SectorEn { get; private set; }
        [StringLength(50)]
        public string MobilePhone { get; private set; }
        [Required]
        [StringLength(50)]
        public string LandLine { get; private set; }
        [StringLength(50)]
        public string Fax { get; private set; }
        public int? Quantity { get; private set; }
        [StringLength(50)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequestDate { get; private set; }

        [ForeignKey("Quantity")]
        [InverseProperty("PrBusinessCardRequest")]
        public PrBusinessCardQuantity QuantityNavigation { get; private set; }
    }
}
