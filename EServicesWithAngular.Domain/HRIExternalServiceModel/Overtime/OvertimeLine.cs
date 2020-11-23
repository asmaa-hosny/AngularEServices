using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class OvertimeLine : BaseModel<long>
    {
        public int? Hours { get; set; }
        public long OvertimeMasterId { get; set; }
        public DateTime? Date { get; set; }
    }
}
