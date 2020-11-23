using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class EmpMission : BaseModel<long>
    {
        public long MissionTypeId { get; set; }
        public string MissionTypeNameAR { get; set; }
        public string MissionTypeNameEN { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public bool IsAdvnacePayment { get; set; }
        public bool IsFoodProvided { get; set; }
        public double FoodTotal { get; set; }
        public bool IsTransportationProvided { get; set; }
        public double TransportationTotal { get; set; }
        public bool IsAccomodationProvided { get; set; }
        public double AccomodationTotal { get; set; }
        public double MandateValue { get; set; }
        public double TransportationValue { get; set; }
        public double FoodValue { get; set; }
        public double GrossAmount { get; set; }
        public double TotalAmount { get; set; }
    }
}
