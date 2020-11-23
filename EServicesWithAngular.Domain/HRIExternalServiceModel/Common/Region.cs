using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class Region : BaseModel<long>
    {
        public string CountryCode { get; set; }
        public string NameAr { get; set; }
        public string NameEng { get; set; }
        public string RegionCode { get; set; }
    }
}
