using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EservicesDomain.Domain.UCcompletion
{
    public class ConsultationCompletionRequest : IKtaEntity<int>
    {
       
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public string ActualDeliverables { get; set; }
        [Required]
        public int ActualDuration { get; set; }
        public string DurationNotes { get; set; }
        public int ActualCost { get; set; }
        public int ConsultationRequestId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string TerminationReason{ get; set; }






    }
}
