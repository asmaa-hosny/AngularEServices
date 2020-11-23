using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
        public long RequestorId { get; set; }
        public string KtaJobId { get; set; }
        public string DOCUMENTNO { get; set; }
        public string DOCSTATUS { get; set; }
        public string DOCACTION { get; set; }
    }
}
