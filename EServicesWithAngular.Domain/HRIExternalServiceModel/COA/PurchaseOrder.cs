
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class PurchaseOrder : BaseModel<long>
    {
        public long? CommitmentId { get; set; }//
        public int? CommitmentLineId { get; set; }
        public long? AccountId { get; set; }//
        public string PurchaseOrderNo { get; set; }
        public string Description { get; set; }
        public string TradeFileNo { get; set; }
        public string PurchaseOrderReference { get; set; }
        public string VendorCode { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string CommitmentNo { get; set; }
        public string VendorNationalityEng { get; set; }
        public string VendorNationalityAr { get; set; }
        public string VendorName { get; set; }
        public string AccountName { get; set; }
        public long? ProjectManagerId { get; set; }//
        public string ProjectManagerEmail { get; set; }
        public long? ProjectManager2Id { get; set; }//
        public string ProjectManager2Email { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? PromiseDate { get; set; }
        public int? PurchaseOrderRemainingAmount { get; set; }
        public int? NetRemainingAmount { get; set; }
        public int? PurchaseOrderPaidAmount { get; set; }
        public int? InProgressAmount { get; set; }
        public int? CommitmentAmount { get; set; }
        public int? CommitmentRemainingAmt { get; set; }
        public int? CommitmentPaidPercent { get; set; }
        public int? PurchaseOrderPaidPercent { get; set; }
        public int? PurchaseOrderAmount { get; set; }
        public int? IsSaudi { get; set; }
        public string PurchaseOrderAmountFormatted { get; set; }
        public string PurchaseOrderRemAmtFormatted { get; set; }


    }
}
