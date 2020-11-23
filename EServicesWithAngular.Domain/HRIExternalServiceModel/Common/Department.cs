using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class Department :BaseModel<long>
    {
        public long ManagerId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
