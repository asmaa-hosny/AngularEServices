using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EServicesApplication.Service.ITSoftware
{
    public class SoftwareRequestItemsModel : IEntity<int>
    {
        public int RequestID { get; set; }

        public int AppID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NeedIsDoneOn { get; set; }

        public string AppName { get; set; }

        public string Justification { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_EmployeeUpdate })]
        public string Link { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.DirectManager_NodeId, ConstantNodes.DepartmentManager_NodeId,
         ConstantNodes.HelpDesk_NodeId, ConstantNodes.ITSolutions_NodeId })]
        public string Status { get; set; }


        [EditWhenNodeID(new short[] { ConstantNodes.DirectManager_NodeId, ConstantNodes.DepartmentManager_NodeId })]

        public string CurrentStatus_En { get; set; }


        [EditWhenNodeID(new short[] { ConstantNodes.DirectManager_NodeId, ConstantNodes.DepartmentManager_NodeId })]

        public string CurrentStatus_Ar { get; set; }


        public string UpdatedBy { get; set; }

        

        //public string CategoryName_Ar { get; set; }

        public string CategoryName_En { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RequestDate { get; set; }



    }
}
