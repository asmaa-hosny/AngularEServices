using EservicesDomain.Attributes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EServicesWithAngular.Domain
{
    public class BusinessTripLine
    {
        public const short NodeId_RequestInitiation = 0;
        public const short NodeId_Personnel = 226;
        public const short NodeId_FinancialEngaggment = 249;
        public const short NodeId_LPRRAccountCheck = 367;
        public const short NodeId_ASToConfirmCosts = 241;
        public const short NodeId_TravelAgencyToEstimateCosts = 353;
        public const short NodeId_Payroll = 295;
        public const short NodeId_FinanceManager = 330;
        public const short NodeId_GiveLoan = 338;
        public const short NodeId_IssueTickets = 291;

        public long LineID { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel })]
        public String Country { get; set; }
      
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel })]
        public long CountryID { get; set; }

        [Required]      
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel })]
        public String Region { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel })]
        public long RegionID { get; set; } 
      
        public int ExtraDaysBefore { get; set; }
   
        public int ExtraDaysAfter { get; set; }

        [Required]   
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel })]
        [DataType(DataType.Date)]
        public DateTime? TripStartDate { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel })]     
        [DataType(DataType.Date)]
        public DateTime? TripEndDate { get; set; }

        [Required]
        [EditWhenNodeID(new short[] {NodeId_RequestInitiation, NodeId_Personnel })]
        public String Reason { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel, NodeId_ASToConfirmCosts })]
        public bool IsLivingProvided { get; set; }
      
        [EditWhenNodeID(new short[] {NodeId_RequestInitiation, NodeId_Personnel, NodeId_ASToConfirmCosts })]    
        public bool IsTransportationNeeded { get; set; }

     
        [EditWhenNodeID(new short[] {NodeId_RequestInitiation, NodeId_Personnel, NodeId_ASToConfirmCosts })]     
        public bool IsVisaNeeded { get; set; }

       
        [EditWhenNodeID(new short[] {NodeId_RequestInitiation, NodeId_Personnel, NodeId_ASToConfirmCosts })]    
        public bool IsCarNeeded { get; set; }

      
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel, NodeId_ASToConfirmCosts })]
        [RequiredIf("IsLivingProvided", true)] 
        //[DynamicDisplayRule("IsLivingProvided", true)]
        [DataType(DataType.Date)]
        public DateTime? LivingStartDate { get; set; }

      
        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel, NodeId_ASToConfirmCosts })]
        [RequiredIf("IsLivingProvided", true)]
        //[DateInterval("LivingStartDate", Operators.GEQ)]
        //[DateInterval("TripStartDate", "ExtraDaysBefore", "TripEndDate", "ExtraDaysAfter", ErrorMessage = "Outside the range")]
        //[DynamicDisplayRule("IsLivingProvided", true)]
        public DateTime? LivingEndDate { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation, NodeId_Personnel, NodeId_ASToConfirmCosts })]     
        public string HotelName { get; set; }

        public String MandateValue { get; set; }
    }
}
