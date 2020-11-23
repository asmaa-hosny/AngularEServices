using EservicesDomain.Attributes;
using EservicesDomain.Common;
using EservicesDomain.Domain.ITServerAccess;
using System.Collections.Generic;

namespace EServicesApplication.Services.ITServerAccess
{
    public class ITServerAccessDTO : BaseDTO
    {
        public ServerAccess DomainModel { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public List<ServerDetails> ServerDetailsItems { get; set; }

    }
}
