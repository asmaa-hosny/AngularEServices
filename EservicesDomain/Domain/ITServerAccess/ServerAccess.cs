using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.Domain.ITServerAccess
{
    public class ServerAccess: IKtaEntity<int>
    {
        public ServerAccess()
        {
            RequiredServersDetails = new List<ServerDetails>();
        }
        [Required]
        public string EmployeeEmail { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystems, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string Username { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string Notes { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string Justification { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public DateTime? DateFrom { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public DateTime? DateTo { get; set; }

        
        public virtual ICollection<ServerDetails> RequiredServersDetails { get; set; }

    }
}
