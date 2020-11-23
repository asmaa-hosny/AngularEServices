using EservicesDomain.Attributes;
using EServicesWithAngular.Domain;
using EServicesWithAngular.Helpers;
using EServicesWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.ViewModels
{
    public class RequisitionBudgetViewModel
    {
        public short NodeID { get; set; }

        public int AccountID { get; set; }
       
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal allyearsbudget { get; set; }
       
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal originalbudgetamt { get; set; }
      
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal TotalBudget { get; set; }
      
       
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal ActualAmount { get; set; }
     
       
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal notissuedamt { get; set; }
     
      
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal totalCommitment { get; set; }
      
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal opencommitment { get; set; }

      
        [StaticDisplayRule(new short[] { Requisition.NodeId_DirectManagerApproval, Requisition.NodeId_DepartmentManagerApproval, Requisition.NodeId_BudgetRequestInformation, Requisition.NodeId_ProcurementRequestInformation }, false)]
        public Decimal remBudget { get; set; }
    }
}
