using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class BusinessTripLine :BaseModel<long>
    {
        public virtual BusinessTrip BusinessTrip { get; set; }

        public virtual Country Country { get; set; }
        public virtual Region City { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? DaysCount { get; set; }
        public int? ExtraDays { get; set; }
        public string FlightType { get; set; }
        public double? MandateValue { get; set; }
        public string Notes { get; set; }
        public string Reason { get; set; }
        public double? TransportationValue { get; set; }
        public int? LivingDeductDays { get; set; }
        public double? LivingCost { get; set; }
        public double? LivingDeductDaysAmount { get; set; }
        public int? TransDeductDays { get; set; }
        public double? TransDeductDaysAmount { get; set; }
        public double? TransportCost { get; set; }
        public double? FoodDeductDaysAmount { get; set; }
        public int? FoodDeductDays { get; set; }
        public int? ExtraDaysAfter { get; set; }
        public int? ExtraDaysBefore { get; set; }
        public bool? IsAccomedatoinRequired { get; set; }
        public DateTime? LivingCheckInDate { get; set; }
        public DateTime? LivingCheckOutDate { get; set; }
        public string SuggestedHotelName { get; set; }
        public double? GrossAmount { get; set; }
        public bool? IsLivingProvided { get; set; }
        public bool? IsFoodRequired { get; set; }
        public bool? IsTransportationRequired { get; set; }
        public double? AccomedationCost { get; set; }
        public bool? IsReplactTicketWithCar { get; set; }
        public bool? IsVisaRequired { get; set; }
    }
}
