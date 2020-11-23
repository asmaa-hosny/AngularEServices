using EServicesApplication.Services.Common;
using EservicesDomain.Attributes;
using EservicesDomain.Common;
using EservicesDomain.Domain;
using EservicesDomain.ExternalDomain.KTA;

using System.Collections.Generic;


namespace EServicesApplication.Services.Resignation
{
    public class ITResignationDTO : BaseDTO
    {
        public List<ListItemModel<string>> StatusList { get; set; }

        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_ERP, ConstantNodes.NodeId_Email_AD, ConstantNodes.NodeId_FAX, ConstantNodes.NodeId_Muraslat, ConstantNodes.NodeId_Port, ConstantNodes.NodeId_SFTP, ConstantNodes.NodeId_SharePoint, ConstantNodes.NodeId_Software_Licenses, ConstantNodes.NodeId_TelePhone, ConstantNodes.NodeId_VPN })]
        public List<ITResignationStatusModel> ItemStatus { get; set; }

        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_RequestInitiation })]
        public ITResignation DomainModel { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeeUser { get; set; }

        public List<PassedItems> Items { get; set; }

        public List<PassedItems> CompletedIems { get; set; }
    }
}
