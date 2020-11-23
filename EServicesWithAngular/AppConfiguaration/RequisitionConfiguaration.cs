using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.AppConfiguaration
{
    public class RequisitionConfiguaration
    {
        #region Variables

        public static IConfiguration _config;

        #endregion

        #region Constructor

        private RequisitionConfiguaration(IConfiguration config)
        {
            _config = config;
        }

        #endregion



        public static  string RequisitionProcessID
        {
            get => _config["KTAProcesses:Requisition:KTA_PROCESS_ID"];
        }

        public static string RequisitionListName
        {
            get => _config["KTAProcesses:Requisition:ATTACHMENTS_LIST_NAME"];
        }

        public static long NodeIdRequestInitiation
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_RequestInitiation"]);
        }

        public static long NodeIdDirectManagerApproval
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_DirectManagerApproval"]);
        }
        public static long NodeIdDepartmentManagerApproval
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_DepartmentManagerApproval"]);
        }
        public static long NodeIdBudgetProcessing
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_BudgetProcessing"]);
        }
        public static long NodeIdBudgetApproval
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_BudgetApproval"]);
        }
        public static long NodeIdProcurementProcessing
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_ProcurementProcessing"]);
        }
        public static long NodeIdProcurementApproval
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_ProcurementApproval"]);
        }
        public static long NodeIdBudgetRequestInformation
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_BudgetRequestInformation"]);
        }
        public static long NodeIdProcurementRequestInformation
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_ProcurementRequestInformation"]);
        }
        public static long NodeIdAuthorityOwnerApproval
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_AuthorityOwnerApproval"]);
        }
        public static long NodeIdRequisitionProcessing
        {
            get => Convert.ToInt32(_config["KTAProcesses:Requisition:NodeId_RequisitionProcessing"]);
        }

    }
}
