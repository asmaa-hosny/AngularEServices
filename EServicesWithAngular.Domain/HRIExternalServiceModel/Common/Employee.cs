using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.HRIExternalServiceModel
{
    public class Employee : BaseModel<long>
    {
        public string KacareId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string NationalId { get; set; }
        public long? SupervisorId { get; set; }
        public long? WorkingCountryId { get; set; }
        public long? DepartmentId { get; set; }
        public long? SectorId { get; set; }
        public long? SectionId { get; set; }
        public DateTime HireDate { get; set; }
        public int COBoxValue { get; set; }
        public bool IsOut { get; set; }
        public bool IsEmployee { get; set; }

        public virtual Department Department { get; set; }
        public virtual Department Sector { get; set; }
        public virtual Department Section { get; set; }
        public virtual Nationality Nationality { get; set; }
        public bool? CanSubmitRetroactiveRequests { get; set; }
        public decimal? MandateBalance { get; set; }
    }
}
