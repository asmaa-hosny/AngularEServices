
using EservicesDomain.Attributes;
using System;


namespace EServicesWithAngular.Domain
{
    public class MissionCompletion : BaseEntity<Int64>
    {
        private const short NodeId_Personnel = 350;
        private const short NodeId_Training = 352;
        private const short NodeId_Payroll = 353;
        private const short NodeId_Committment = 357;
        private const short NodeId_FinanceManager = 358;
        private const short NodeId_FinanceTeam = 359;
        private const short NodeId_RequestInitiation = 0;

        public long MissionID { get; set; }

        public string DocumentType { get; set; }

        public long EmployeeID { get; set; }

        public int MissionTypeID { get; set; }

        public string MissionTypeEn { get; set; }

        public string MissionTypeAr { get; set; }

        public string DateFrom { get; set; }

        public string DateTo { get; set; }
        
        public DateTime CompletedDate { get; set; }

        public string City { get; set; }

        public int CityId { get; set; }

        public string Country { get; set; }

        public int CountryId { get; set; }

        [EditWhenNodeID(false)]
        public bool IsAdvancedPaymentNeeded { get; set; }

        [EditWhenNodeID(false)]
        public decimal AdvancedPaymentTotal { get; set; }

        [EditWhenNodeID(false)]
        public bool IsAccomedatoinProvided { get; set; }

        [EditWhenNodeID(false)]
        public decimal AccomedationPaymentTotal { get; set; }

        [EditWhenNodeID(false)]
        public bool IsFoodProvided { get; set; }

        [EditWhenNodeID(false)]
        public decimal FoodPaymentTotal { get; set; }

        [EditWhenNodeID(false)]
        public bool IsTransportationProvided { get; set; }

        [EditWhenNodeID(false)]
        public decimal TransportationPaymentTotal { get; set; }

        public decimal MandateValue { get; set; }

        [EditWhenNodeID(false)]
        public decimal TransportationValue { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public int EarlyDays { get; set; }

        public string EarlyDaysReason { get; set; }

        public bool IsMandate { get; set; }

        public bool IsTraining { get; set; }

        public bool IsOvertime { get; set; }

        public bool IsReportNeeded { get; set; }

        public decimal LoanValue { get; set; }

        [StaticDisplayRule(new short[] { NodeId_Committment,NodeId_FinanceManager,NodeId_FinanceManager })]
        [EditWhenNodeID(new short[] { NodeId_Personnel, NodeId_Payroll,NodeId_Training })]
        public long LivingDeductDays { get; set; }

        [StaticDisplayRule(new short[] { NodeId_Committment, NodeId_FinanceManager, NodeId_FinanceManager })]
        [EditWhenNodeID(new short[] { NodeId_Personnel, NodeId_Payroll, NodeId_Training })]
        public decimal OtherAllowance { get; set; }

        [StaticDisplayRule(new short[] { NodeId_Committment, NodeId_FinanceManager, NodeId_FinanceManager })]
        [EditWhenNodeID(new short[] { NodeId_Personnel, NodeId_Payroll, NodeId_Training })]
        public decimal OtherDeduction { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation })]
        public string OtherDeductionReason { get; set; }

        [StaticDisplayRule(new short[] { NodeId_Committment, NodeId_FinanceManager, NodeId_FinanceManager })]
        [EditWhenNodeID(new short[] { NodeId_Personnel, NodeId_Payroll, NodeId_Training })]
        public long TransDeductDays { get; set; }

        [StaticDisplayRule(new short[] { NodeId_Committment, NodeId_FinanceManager, NodeId_FinanceManager })]
        [EditWhenNodeID(new short[] { NodeId_Personnel, NodeId_Payroll, NodeId_Training })]
        public long FoodDeductDays { get; set; }




      



    }
}
