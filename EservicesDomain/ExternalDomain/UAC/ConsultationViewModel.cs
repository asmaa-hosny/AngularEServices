using System;

namespace EservicesDomain.ExternalDomain.UAC
{
    public class ConsultationViewModel
    {
        public string ConsultantName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string RequestType { get; set; }

        public int Duration { get; set; }

        public int? ActualDuration { get; set; }

        public int? EstimatedCost { get; set; }

        public int? ActualCost { get; set; }

        public string Status { get; set; }
    }
}
