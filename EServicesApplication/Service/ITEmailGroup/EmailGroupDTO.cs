using EServicesApplication.Service.ITEmailGroup;
using EservicesDomain.Attributes;
using EservicesDomain.Common;
using EservicesDomain.Domain;
using EservicesDomain.Domain.ITGroupEmail;
using EservicesDomain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EServicesApplication.Services.ITEmailGroup
{
    public class EmailGroupDTO : BaseDTO
    {
   
        private string _powershellScript;

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_EmployeeToUpdate })]
        public List<EmailGroupMember> GroupMember { get; set; }

        public EmailGroup DomainModel { get; set; }
        public bool createEmailGroup { get; set; }

        public string PowerShellCodeForAddingGroupEmail
        {
            get { return _powershellScript; }
            set { _powershellScript = value; }
        }
        public string AddGroupEmail()
        {
            StringBuilder members = new StringBuilder();
            _powershellScript = SkeletonMapper.MapObjectToSkeleton(
                                                 new AddNewGroupEmail()
                                                 {
                                                     GroupName = this.DomainModel.EmailName,
                                                     GroupEmail = this.DomainModel.EmployeeEmail,
                                                     DisplayName = this.DomainModel.EmailName,
                                                     MangedBy = this.DomainModel.EmployeeEmail,
                                                     Members = "members",

                                                 }, forJavaScript: true);
            if (DomainModel != null && GroupMember.Count > 0)
            {
                int i = 0;
                foreach (var item in GroupMember)
                {
                     // members.Append((Expression<Func<GroupMembersModel, string>>)(x => x.MemberEmail));
                    members.Append(this.GroupMember[i].MemberEmail).Append(',');

                    i++;
                }
               // members.Remove(members.Length - 3, 3);//remove last ,
               // members.Remove(0, 2);// First tow chars,

                this._powershellScript = this. _powershellScript.Replace("$('#members').val()", members.ToString());

            }
            return _powershellScript;


        }
    }
}
