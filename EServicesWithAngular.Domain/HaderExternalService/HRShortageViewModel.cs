using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HaderExternalService
{
    public class HRShortageViewModel
    {
        public long EmployeeId { get; set; }
        public DateTime WorkDate { get; set; }
        public TimeSpan? Hrshortage { get; set; }
        public DateTime? S1In { get; set; }
        public DateTime? S1Out { get; set; }
    }
}
