using EServicesApplication.Services;
using EservicesDomain.Attributes;
using EservicesDomain.Common;
using EservicesDomain.Domain.ITSoftware;
using System.Collections.Generic;

namespace EServicesApplication.Service.ITSoftware
{
    public class SoftwareDTO : BaseDTO
    {
        public Software DomainModel { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.HelpDesk_NodeId })]
        public List<SoftwareRequestItemsModel> EmployeeRequestsHistory { get; set; }
        
        
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation })]
        public List<SoftwareRequestItemsModel> ITSoftwareRequestItems { get; set; }



    }
}
