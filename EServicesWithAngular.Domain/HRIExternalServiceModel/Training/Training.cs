using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class Training : BaseModel<long>
    {
        public virtual Employee Delegate { get; set; }
        public string CourseTitle { get; set; }
        public bool? NoHousing { get; set; }
        public string OtherInformation { get; set; }
        public ICollection<TrainingLine> Lines { get; set; }
        public string CommitteeDecision { get; set; }
    }
}
