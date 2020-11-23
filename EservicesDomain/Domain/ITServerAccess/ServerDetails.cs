using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.Domain.ITServerAccess
{
    public class ServerDetails: IEntity<int>
    {
        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string ServerName { get; set; }
        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string ServerIP { get; set; }
        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public Boolean IsAdmin { get; set; }

        public int AssociatedTo { get; set; }
    }
}
