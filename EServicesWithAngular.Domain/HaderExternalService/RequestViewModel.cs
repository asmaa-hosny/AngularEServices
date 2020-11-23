using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HaderExternalService
{
    public class RequestViewModel
    {
        public long EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Notes { get; set; }
      
    }
}
