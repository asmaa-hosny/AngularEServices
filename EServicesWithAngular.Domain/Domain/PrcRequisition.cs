using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration;
using EServicesWithAngular;
using EServicesWithAngular.Domain.Common;
using EServicesWithAngular.Domain.Commo;

namespace EServicesWithAngular.Domain
{
    [Table("PRC_Requisition")]
    public class PrcRequisition
    {
      

        public PrcRequisition()
        {
            PrcRequisitionVendors = new HashSet<PrcRequisitionVendors>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; set; }
        [Column("REF_ID")]
        [StringLength(15)]
        public string RefId { get; set; }
        [StringLength(1000)]
        public string ProjectName { get; set; }
        [Column(TypeName = "money")]
        public decimal? EstimatedCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column("RequisitionApprovalREF_ID")]
        [StringLength(10)]
        public string RequisitionApprovalRefId { get; set; }
        [StringLength(100)]
        public string EmployeeMail { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
        [Column("RequisitionTypeID")]
        [StringLength(15)]
        public string RequisitionTypeId { get; set; }
        public double? DocumentsPrice { get; set; }
        public int? ProjectPeriodinMonth { get; set; }
        [Column("RequisitionNatureID")]
        public int RequisitionNatureId { get; set; }
        public bool OneMillionPlus { get; set; }
        [Column("ProjectTypeID")]
        public int? ProjectTypeId { get; set; }

        [ForeignKey("ProjectTypeId")]
        [InverseProperty("PrcRequisition")]
        public PrcRequisitionProjectTypes ProjectType { get; set; }
        [ForeignKey("RequisitionNatureId")]
        [InverseProperty("PrcRequisition")]
        public PrcRequisitionNature RequisitionNature { get; set; }
        [InverseProperty("Requisition")]
        public ICollection<PrcRequisitionVendors> PrcRequisitionVendors { get; set; }
        public string AttachementListName => StaticClass.Configuration["KTAProcesses:Requisition:ATTACHMENTS_LIST_NAME"];

        public static PrcRequisition Create(int Id, string JobId, string RefId, string ProjectName, decimal? EstimatedCost, DateTime? StartDate, DateTime? EndDate, string RequisitionApprovalRefId,
            string EmployeeMail, int? AccountId, string RequisitionTypeId, double? DocumentsPrice, int? ProjectPeriodinMonth, int RequisitionNatureId, bool OneMillionPlus, int? ProjectTypeId,
            PrcRequisitionProjectTypes ProjectType, PrcRequisitionNature RequisitionNature, ICollection<PrcRequisitionVendors> PrcRequisitionVendors)
        {
            return new PrcRequisition()
            {
                Id = Id,
                JobId = JobId,
                RefId = RefId,
                ProjectName = ProjectName,
                EstimatedCost = EstimatedCost,
                StartDate = StartDate,
                EndDate = EndDate,
                RequisitionApprovalRefId = RequisitionApprovalRefId,
                EmployeeMail = EmployeeMail,
                AccountId = AccountId,
                RequisitionTypeId = RequisitionTypeId,
                DocumentsPrice = DocumentsPrice,
                ProjectPeriodinMonth = ProjectPeriodinMonth,
                RequisitionNatureId = RequisitionNatureId,
                OneMillionPlus = OneMillionPlus,
                ProjectTypeId = ProjectTypeId,
                ProjectType = ProjectType,
                RequisitionNature = RequisitionNature,
                PrcRequisitionVendors = PrcRequisitionVendors
               
            };
        }
    }
}
