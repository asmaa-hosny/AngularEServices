using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesApplication.Service.ITEmailGroup
{
   public class GroupMembersModel
    {
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string MemberEmail { get; set; }
    }
}
