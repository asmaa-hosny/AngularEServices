using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EservicesDomain.Domain.ITSoftware
{
    public class SoftwareRequestItems : IEntity<int>
    {
        public int RequestID { get; set; }

        public int AppID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NeedIsDoneOn { get; set; }

        public string AppName { get; set; }

        public string Justification { get; set; }
        public string Link { get; set; }
       

        [EditWhenNodeID(new short[] { ConstantNodes.DirectManager_NodeId, ConstantNodes.DepartmentManager_NodeId,
         ConstantNodes.HelpDesk_NodeId, ConstantNodes.ITSolutions_NodeId })]
        public string Status { get; set; }
        
        public string UpdatedBy { get; set; }

        public virtual Software ITSoftware { get; set; }
        public virtual SoftwareApps ITSoftwareApps { get; set; }
        public virtual ITStatus ITStatuses { get; set; }
    }
}
