
using EservicesDomain.Attributes;
using EservicesDomain.Common;

namespace EservicesDomain.Domain
{
   public class EmailGroupMember : IEntity<int>
    {
        public int AssociatedTo { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string MemberEmail { get; set; }
    }
}
