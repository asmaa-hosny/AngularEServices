using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class Country : BaseModel<long>
    {
        public string ArabicTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string CountryCode { get; set; }
    }
}
