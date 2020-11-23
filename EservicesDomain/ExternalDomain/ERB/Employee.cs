using System;


namespace EservicesDomain.ExternalModel.ERB
{
    public class Employee
    {
        public long Id { get; set; }
        public String KacareId { get; set; }
        public String EmployeeName { get; set; }
        public String EmployeeNameAr{ get; set; }
        public String EmployeeNameEn{ get; set; }
        public String Greeting { get; set; }
        public String GreetingAr{ get; set; }
        public String GreetingEn{ get; set; }
        public long? SupervisorId { get; set; }
        public String SupervisorNameAr { get; set; }
        public String SupervisorNameEn { get; set; }
        public String SupervisorEmail { get; set; }
        public String Email { get; set; }
        public String EmployeeDepartment { get; set; }
        public long? DepartmentManagerId { get; set; }
        public String Specialization { get; set; }
        public String DepartmentAr{ get; set; }
        public String DepartmentEn{ get; set; }
        public String DepartmentManagerAr{ get; set; }
        public String DepartmentManagerEn{ get; set; }
        public String DepartmentManagerEmail { get; set; }
        public String SectorHeadeMail { get; set; }
        public String Balance { get; set; }
        public String NetBalance { get; set; }
        public String Grade { get; set; }
        public String Gender { get; set; }
        public String GradeName { get; set; }
        public String NationalId { get; set; }
        public String EmployeeExperience { get; set; }
        public String HireDate { get; set; }
        public String JobTitle { get; set; }
        public String JobTitleAr{ get; set; }
        public String JobTitleEn{ get; set; }
        public String Nationality { get; set; }
        public String NationalityAr{ get; set; }
        public String NationalityEn{ get; set; }
        public String PassportNo { get; set; }
        public String SectionName { get; set; }
        public String SectionNameAr{ get; set; }
        public String SectionNameEn{ get; set; }
        public String IsSaudi { get; set; }
        public String EmpCode { get; set; }
        public String Username { get; set; }
        public String DefaultAirClass { get; set; }
        public String OfficeLocation { get; set; }
        public String Mobile { get; set; }

    }
}
