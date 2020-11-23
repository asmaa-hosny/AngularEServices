using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class Overtime :BaseModel<long>
    {

        public long? C_DOCTYPE_ID { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int Days { get; set; }
        public int? Duration { get; set; }
        public int? HoursInWeekends { get; set; }
        public int? Hours { get; set; }
        public int? DurationInWeekends { get; set; }
        public bool? OnSaturday { get; set; }
        public bool? OnSunday { get; set; }
        public bool? OnMonday { get; set; }
        public bool? OnTuesday { get; set; }
        public bool? OnWednesday { get; set; }
        public bool? OnThursday { get; set; }
        public bool? OnFriday { get; set; }
        public double? OvertimeValue { get; set; }
        public int? ActualOvertimeDays { get; set; }
        public int? ChosenDaysCount { get; set; }
        public virtual ICollection<OvertimeLine> OvertimeLines { get; set; }
    }
}
