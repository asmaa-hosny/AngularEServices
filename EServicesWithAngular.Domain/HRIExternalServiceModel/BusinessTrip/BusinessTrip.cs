using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class BusinessTrip : BaseModel<long>
    {
        public virtual Employee Requestor { get; set; }
        public virtual Employee Delegate { get; set; }
        public long? DelegateId { get; set; }
        public ICollection<BusinessTripLine> Lines { get; set; }      
        public Country Country { get; set; }
        public Region City { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? DaysCount { get; set; }
        public int? ExtraDays { get; set; }
        public string FlightType { get; set; }
        public string BusinessTripType { get; set; }
        public decimal? MandateValue { get; set; }
        public string Notes { get; set; }
        public string Reason { get; set; }
        public string RecommendationType { get; set; }
        public decimal? TransportationValue { get; set; }
        public long? SubsituteEmployeeId { get; set; }
        public long? NTPInitiativeId { get; set; }
        public decimal? TotalValues { get; set; }
        public string AireClass { get; set; }
        public int? LivingDeductDays { get; set; }
        public decimal? LivingCost { get; set; }
        public decimal? LivingDeductDaysAmount { get; set; }
        public int? TransDeductDays { get; set; }
        public decimal? VisaCost { get; set; }
        public decimal? TransDeductDaysAmount { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal? FoodDeductDaysAmount { get; set; }
        public int? FoodDeductDays { get; set; }
        public decimal? TicketAmount { get; set; }
        public string IsSectorApproval { get; set; }
    }
}

