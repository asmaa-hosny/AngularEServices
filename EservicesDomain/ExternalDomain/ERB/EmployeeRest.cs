using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.ExternalDomain.ERB
{
    public class EmployeeRest
    {
        public int Id { get; set; }

        public int KacareId { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string ArabicName { get; set; }

        public string EnglishName { get; set; }

        public string NationalId { get; set; }

        public int SupervisorId { get; set; }

        public int DepartmentId { get; set; }

        public int SectorId { get; set; }

        public DateTime HireDate { get;set;}

        public Department Department { get; set; }

        public Department Sector  { get; set; }
    }

    public class Department
    {
        public int ManagerId { get; set; }

        public string ArabicName { get; set; }

        public string EnglishName { get; set; }

        public int Id { get; set; }
    }
}
