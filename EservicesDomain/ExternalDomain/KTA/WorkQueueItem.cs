using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.ExternalModel.KTA
{
    public class WorkQueueItem
    {
        public string JobSLA { get; set; }
        public string ProcessName { get; set; }
        public string ActivitySLA { get; set; }
        public string ActivityName { get; set; }
        public DateTime DueDate { get; set; }
        public string AssignedTo { get; set; }
        public string EmployeeName { get; set; }
        public string REF_ID { get; set; }
        public string JobId { get; set; }
        public short NodeId { get; set; }
        public short EPC { get; set; }
        public string AssociatedFile { get; set; }
    }
}