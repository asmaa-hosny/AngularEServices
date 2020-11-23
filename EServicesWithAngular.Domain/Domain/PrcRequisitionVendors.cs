using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PRC_Requisition_Vendors")]
    public class PrcRequisitionVendors
    {
        private PrcRequisitionVendors()
        {
        }

        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string VendorName { get; set; }
        [StringLength(50)]
        public string PhoneNo { get; set; }
        [StringLength(50)]
        public string FaxNo { get; set; }
        [Column("eMail")]
        [StringLength(50)]
        public string EMail { get; set; }
        [Column("RequisitionID")]
        public int RequisitionId { get; set; }

        [ForeignKey("RequisitionId")]
        [InverseProperty("PrcRequisitionVendors")]
        public PrcRequisition Requisition { get; set; }

        public static PrcRequisitionVendors Create(int id,string VendorName, string PhoneNo, string FaxNo, string EMail, int RequisitionId)
        {
            return new PrcRequisitionVendors()
            {
                Id = id,
                VendorName = VendorName,
                PhoneNo = PhoneNo,
                FaxNo = FaxNo,
                EMail = EMail,
                RequisitionId = RequisitionId
            };
        }

      
    }


  
}
