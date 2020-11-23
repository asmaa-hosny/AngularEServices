using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class MissionCompletion : BaseModel<long>
    {
        private const short NodeId_Personnel = 350;
        private const short NodeId_Training = 352;
        private const short NodeId_Payroll = 353;
        private const short NodeId_Committment = 357;
        private const short NodeId_FinanceManager = 358;
        private const short NodeId_FinanceTeam = 359;
        private const short NodeId_RequestInitiation = 0;

        public long MissionTypeId { get; set; }
        public string MissionTypeNameAR { get; set; }
        public string MissionTypeNameEN { get; set; }
        public bool IsAdvnacePayment { get; set; }
        public bool IsFoodProvided { get; set; }
        public double FoodTotal { get; set; }
        public bool IsTransportationProvided { get; set; }
        public double TransportationTotal { get; set; }
        public bool IsAccomodationProvided { get; set; }
        public double AccomodationTotal { get; set; }
        public double MandateValue { get; set; }
        public double FoodValue { get; set; }
        public double TotalAmount { get; set; }

        public virtual Country Country { get; set; }
        public virtual Region Region { get; set; }
        public virtual Employee Requestor { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? ExtraDays { get; set; }
        public string Reason { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? MandatValue { get; set; }
        public int? Days { get; set; }
        public int? TotalDays { get; set; }
        public decimal? TransportationValue { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? NetAmount { get; set; }
        public bool IsLiving { get; set; }
        public bool IsFood { get; set; }
        public bool IsTransport { get; set; }
        public string ExtraDaysReason { get; set; }
        public long? BusinessTripId { get; set; }
        public long? OvertimeId { get; set; }
        public long? TrainingId { get; set; }
        public long? BusinesTripLineId { get; set; }
        public int? LivingDeductDays { get; set; }
        public int? TransDeductDays { get; set; }
        public int? FoodDeductDays { get; set; }
        public string OtherDeductionReason { get; set; }
        public int EarlyDays { get; set; }
        public long? CountryId { get; set; }
        public long? RegionId { get; set; }
    }
}
