using EServicesWithAngular.Domain;
using System.Collections.Generic;

namespace EServicesWithAngular.Domain
{
    public class RequisitionVendor : BaseEntity<int>
    {

        public string VendorName { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EMail { get; set; }
        public int RequisitionID { get; set; }

        public static RequisitionVendor Create(int id,string VendorName, string PhoneNo, string FaxNo, string EMail, int RequisitionId)
        {
            return new RequisitionVendor()
            {
                Id=id,
                VendorName = VendorName,
                PhoneNo = PhoneNo,
                FaxNo = FaxNo,
                EMail = EMail,
                RequisitionID = RequisitionId
            };
        }


        public static implicit operator PrcRequisitionVendors(RequisitionVendor Vendor)
        {
            return PrcRequisitionVendors.Create(Vendor.Id, Vendor.VendorName, Vendor.PhoneNo, Vendor.FaxNo,
                Vendor.EMail, Vendor.RequisitionID);
        }

      

        public static ICollection<PrcRequisitionVendors> CastToListOfVendors(ICollection<RequisitionVendor> VendorsDTO)
        {
            ICollection<PrcRequisitionVendors> vendors = new List<PrcRequisitionVendors>();
            if (VendorsDTO != null && VendorsDTO.Count > 0)
                foreach (RequisitionVendor one in VendorsDTO)
                {
                    vendors.Add(
                        PrcRequisitionVendors.Create(one.Id,one.VendorName, one.PhoneNo, one.FaxNo,
                    one.EMail, one.RequisitionID)
                        );
                }

            return vendors;
        }
        public static ICollection<RequisitionVendor> CastToListOfVendors(ICollection<PrcRequisitionVendors> Vendors)
        {
            ICollection<RequisitionVendor> vendors = new List<RequisitionVendor>();
            if (Vendors != null && Vendors.Count > 0)
                foreach (RequisitionVendor one in Vendors)
                {
                    vendors.Add(
                        RequisitionVendor.Create(one.Id,one.VendorName, one.PhoneNo, one.FaxNo,
                    one.EMail, one.RequisitionID)
                        );
                }

            return vendors;
        }

        public static implicit operator RequisitionVendor(PrcRequisitionVendors Vendor)
        {
            return RequisitionVendor.Create(Vendor.Id,Vendor.VendorName, Vendor.PhoneNo, Vendor.FaxNo,
                Vendor.EMail, Vendor.RequisitionId);
        }
    }
}
