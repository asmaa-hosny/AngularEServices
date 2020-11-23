using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class Nationality : BaseModel<long>
    {
        public string NationalityName { get; set; }
        public string NationalityCode { get; set; }
        public bool IsLocal { get; set; }
    }
}
