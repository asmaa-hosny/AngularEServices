using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.Domain.UC
{
    public class ConsultationRequest : IKtaEntity<int>
    {
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public string ServiceRequired { get; set; }
        [Required]
        public string RequestType { get; set; }
        [Required]
        public string ResearchTitle { get; set; }

        [Required]
        public int RequestTypeId { get; set; }
        [Required]
        public string ExpectedDeliverables { get; set; }
        [Required]
        public string Objectives { get; set; }
        [Required]
        public int Duration { get; set; }
        
        public int EstimatedCost { get; set; }
        
        public string DurationNote { get; set; }
        [Required]
        public DateTime? DateFrom { get; set; }
        [Required]
        public DateTime? DateTo { get; set; }
        public bool IsInvolved { get; set; }
        [Required]
        public int UniversityId { get; set; }
        [Required]
        public string UniversityName { get; set; }
       
        public int? ResearchAreasId { get; set; }
        public string ResearchArea { get; set; }
        public string EricEmail { get; set; }
        public string RegisteredConsultantId { get; set; }
        public bool IsRelationWCounsultant { get; set; }
        public int ResearchType { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.UCP_Admin__NodeId, ConstantNodes.Research_Collaboration_Committee , ConstantNodes.DM_NodeID })]
        public bool IsConfidential { get; set; }


        //Not registered Fellow/Consultant
        [RequiredIf("IsInvolved", false)]
        public string ConsultantName { get; set; }
        [RequiredIf("IsInvolved", false)]
        public string ConsultantDetails { get; set; }
        [RequiredIf("IsInvolved", false)]
        public string ConsultantNumber { get; set; }
        [RequiredIf("IsInvolved", false)]
        public string ConsultantEmail { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }












    }
}
