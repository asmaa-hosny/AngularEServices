using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class TrainingLine : BaseModel<long>
    {
        public virtual Training Training { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Country Country { get; set; }
        public virtual Region City { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? Days { get; set; }
     
        public int? ExtraDaysAfter { get; set; }
        public int? ExtraDaysBefore { get; set; }
        public string Notes { get; set; }
        public double? MandateValue { get; set; }
        public bool? IsTransportation { get; set; }
        public bool? IsTicketProvidedByProvider { get; set; }
        public bool? IsVisa { get; set; }
        public bool? IsLiving { get; set; }
        public bool? IsAdvancedPayment { get; set; }
        public bool? IsInCompetencyPlan { get; set; }
        public bool? IsSimilarCourseOfferedInHouse { get; set; }
        public int? TransportationDeductionDays { get; set; }
        public double? TransportationDeductionAmount { get; set; }
        public double? TransportationValue { get; set; }
        public double? TransportCost { get; set; }
        public DateTime? LivingCheckInDate { get; set; }
        public DateTime? LivingCheckOutDate { get; set; }
        public string SuggestedHotelName { get; set; }
        public int? LivingDeductionDays { get; set; }
        public double? LivingDeductionAmount { get; set; }
        public double? LivingCost { get; set; }
        public string VisaType { get; set; }
        public double? AdvancedPaymentAmount { get; set; }
        public Currency Currency { get; set; }
        public string CourseType { get; set; }
        public double? AmountCost { get; set; }
        public double? Amount { get; set; }
        public long? InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string FlightType { get; set; }
        public string AirClass { get; set; }
        public string EmployeeRole { get; set; }
        public string ProgramGoal { get; set; }
        public string WhyThisEmployee { get; set; }
        public string Competencies { get; set; }
        public string URL { get; set; }
        public string TrainingCenter { get; set; }
        public double? TicketAmount { get; set; }
        public double? VisaCost { get; set; }
    }
}
