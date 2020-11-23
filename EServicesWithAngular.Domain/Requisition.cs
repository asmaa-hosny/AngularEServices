using EservicesDomain.Attributes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EServicesWithAngular.Domain
{
    [Serializable]
    public class Requisition : BaseEntity<int>
    {

        public const short NodeId_RequestInitiation = 0;
        public const short NodeId_DirectManagerApproval = 474;
        public const short NodeId_DepartmentManagerApproval = 456;
        public const short NodeId_BudgetProcessing = 461;
        public const short NodeId_BudgetApproval = 487;
        public const short NodeId_ProcurementProcessing = 488;
        public const short NodeId_ProcurementApproval = 489;
        public const short NodeId_BudgetRequestInformation = 494;
        public const short NodeId_ProcurementRequestInformation = 496;
        public const short NodeId_AuthorityOwnerApproval = 491;
        public const short NodeId_RequisitionProcessing = 495;


        public virtual ICollection<RequisitionVendor> Vendors { get; set; }
        [Required]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        [RegularExpression(@"^[\u0621-\u064A\u0660-\u0669 ]+$")]
        public string ProjectName { get; set; }

        [RequiredIf("NodeID", new short[] { NodeId_RequestInitiation }, Operators.EQ)]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        public Nullable<decimal> EstimatedCost { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        public Nullable<System.DateTime> StartDate { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        public Nullable<System.DateTime> EndDate { get; set; }

        public string RequisitionApprovalREF_ID { get; set; }

        [RequiredIf("NodeID", new short[] { NodeId_BudgetApproval, NodeId_BudgetApproval }, Operators.EQ)]
        [EditWhenNodeID(new short[] { NodeId_BudgetProcessing, NodeId_BudgetApproval })]
        [StaticDisplayRule(new short[] {NodeId_RequestInitiation, NodeId_DirectManagerApproval, NodeId_DepartmentManagerApproval,
             NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation }, false)]
        public int? AccountID { get; set; }

        [EditWhenNodeID(new short[] { NodeId_ProcurementProcessing, NodeId_ProcurementApproval })]
        [StaticDisplayRule(new short[] { NodeId_RequestInitiation,NodeId_DirectManagerApproval, NodeId_DepartmentManagerApproval,
             NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation, NodeId_BudgetProcessing,
             NodeId_BudgetApproval}, false)]
        public string RequisitionTypeID { get; set; }

        [EditWhenNodeID(new short[] { NodeId_ProcurementProcessing, NodeId_ProcurementApproval })]
        [RequiredIf("RequisitionTypeID", "T", Operators.EQ)]
        public Nullable<double> DocumentsPrice { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        public int? ProjectPeriodinMonth { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_ProcurementProcessing, NodeId_ProcurementApproval })]
        public int RequisitionNatureID { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        public bool OneMillionPlus { get; set; }

        [RequiredIf("NodeID", new short[] { NodeId_RequestInitiation }, Operators.EQ)]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        public int? ProjectTypeID { get; set; }

        public string EmployeeMail { get; set; }

       // [RequiredIf("RequisitionNatureID", 18, Operators.EQ, ErrorMessageResourceType = typeof(RequisitionResource), ErrorMessageResourceName = "OtherNature")]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation,NodeId_BudgetRequestInformation, NodeId_ProcurementRequestInformation })]
        public string OtherNature { get; set; }

      

        #region Implicit Conversion

        public static implicit operator PrcRequisition(Requisition dto)
        {
            PrcRequisitionNature PrcRequisitionNature=null;

            if (!string.IsNullOrEmpty(dto.OtherNature))
            {
                PrcRequisitionNature = new PrcRequisitionNature();
                PrcRequisitionNature.RequisitionNatureAr = dto.OtherNature;
                PrcRequisitionNature.RequisitionNatureEn = dto.OtherNature;
            }

            return PrcRequisition.Create(dto.Id, dto.JobID, dto.REF_ID, dto.ProjectName, dto.EstimatedCost, dto.StartDate, dto.EndDate, dto.RequisitionApprovalREF_ID,
                dto.EmployeeMail, dto.AccountID, dto.RequisitionTypeID, dto.DocumentsPrice, dto.ProjectPeriodinMonth, dto.RequisitionNatureID, dto.OneMillionPlus, dto.ProjectTypeID,
                null, PrcRequisitionNature, RequisitionVendor.CastToListOfVendors(dto.Vendors));
        }

        public static implicit operator Requisition(PrcRequisition dto)
        {
            return new Requisition()
            {
                Id = dto.Id,
                JobID = dto.JobId,
                REF_ID = dto.RefId,
                ProjectName = dto.ProjectName,
                EstimatedCost = dto.EstimatedCost,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                RequisitionApprovalREF_ID = dto.RequisitionApprovalRefId,
                EmployeeMail = dto.EmployeeMail,
                AccountID = dto.AccountId,
                RequisitionTypeID = dto.RequisitionTypeId,
                DocumentsPrice = dto.DocumentsPrice,
                ProjectPeriodinMonth = dto.ProjectPeriodinMonth,
                RequisitionNatureID = dto.RequisitionNatureId,
                OneMillionPlus = dto.OneMillionPlus,
                ProjectTypeID = dto.ProjectTypeId,
                Vendors = RequisitionVendor.CastToListOfVendors(dto.PrcRequisitionVendors)
            };
        }

        public static Requisition Create(int Id, string JobId, string RefId, string ProjectName, decimal? EstimatedCost, DateTime? StartDate, DateTime? EndDate, string RequisitionApprovalRefId,
            string EmployeeMail, int? AccountId, string RequisitionTypeId, double? DocumentsPrice, int? ProjectPeriodinMonth, int RequisitionNatureId, bool OneMillionPlus, int? ProjectTypeId,
            ICollection<PrcRequisitionVendors> PrcRequisitionVendors)
        {
            return new Requisition()
            {
                Id = Id,
                JobID = JobId,
                REF_ID = RefId,
                ProjectName = ProjectName,
                EstimatedCost = EstimatedCost,
                StartDate = StartDate,
                EndDate = EndDate,
                RequisitionApprovalREF_ID = RequisitionApprovalRefId,
                EmployeeMail = EmployeeMail,
                AccountID = AccountId,
                RequisitionTypeID = RequisitionTypeId,
                DocumentsPrice = DocumentsPrice,
                ProjectPeriodinMonth = ProjectPeriodinMonth,
                RequisitionNatureID = RequisitionNatureId,
                OneMillionPlus = OneMillionPlus,
                ProjectTypeID = ProjectTypeId,
                Vendors = RequisitionVendor.CastToListOfVendors(PrcRequisitionVendors)
            };
        }

        #endregion
    }
}
