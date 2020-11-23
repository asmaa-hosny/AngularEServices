using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HaderExternalService
{
    public class CheckInViewModel
    {
        public long EmployeeId { get; set; }
        public DateTime CheckINDateTime { get; set; }
        public string ShortTime { get; set; }
    }
}
