using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class CertificateAccomplishWithOrder : BaseModel<long>
    {
        public long OrderId { get; set; }
        public string VendorName { get; set; }
        public string BillNo { get; set; }
        public decimal BillTotalNet { get; set; }
        public decimal BillTotal { get; set; }
        public string ProjectTitle { get; set; }

    }
}
