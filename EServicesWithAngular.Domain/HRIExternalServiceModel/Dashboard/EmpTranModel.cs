using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class EmpTransModel : BaseModel<long>
    {
        public string RequesterName { get; set; }

        public string RequestType { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }


    }
}
