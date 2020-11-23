using EServicesCommon.Common;
using EServicesCommon.Configuaration;
using EServicesCommon.DI;
using EservicesDomain.Attributes;
using EservicesDomain.Common;
using EservicesDomain.Helpers;
using System;   
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using CommonLibrary.Configuaration;
namespace EservicesDomain.Domain.ITGroupEmail
{
   public class EmailGroup : IKtaEntity<int>
    {
        public EmailGroup()
        {
            this.GroupMembers = new HashSet<EmailGroupMember>();
        }
        public string EmployeeEmail { get; set; }
        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystems, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string EmailName { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string Notes { get; set; }
        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public string Justification { get; set; }
        public bool IsNeededForExternal { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public ICollection<EmailGroupMember> GroupMembers { get; set; }
    }
}
