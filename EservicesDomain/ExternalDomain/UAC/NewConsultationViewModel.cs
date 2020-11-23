using System;

namespace EservicesDomain.ExternalDomain.UAC
{
    public class NewConsultationViewModel
    {
        public string EmployeeEmail { get; set; }
        public string JobId { get; set; }
        public string ServiceRequired { get; set; }
        public string RequestType { get; set; }
        public string ExpectedDeliverables { get; set; }
        public string Objectives { get; set; }
        public int Duration { get; set; }
        public int EstimatedCost { get; set; }
        public string DurationNote { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsConfidential { get; set; }

        //is registered fellow
        public bool IsInvolved { get; set; }
        public int UniversityId { get; set; }
        public int? ResearchAreasId { get; set; }
        public string RegisteredConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantDetails { get; set; }
        public string ConsultantNumber { get; set; }
        public string ConsultantEmail { get; set; }
    }
}
