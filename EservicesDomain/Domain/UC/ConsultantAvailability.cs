

using EservicesDomain.Common;
using System;

namespace EservicesDomain.Domain.UC
{
    public class ConsultantAvailability : IEntity<int>
    {
        public int ConsultationRequestId { get; set; }
        public string ConsultantEmail { get; set; }
        public int Days { get; set; }
        public int Year { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
