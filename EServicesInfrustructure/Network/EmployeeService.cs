using CommonLibrary.Configuaration;
using CommonLibrary.Logging;
using ERP_EmployeeServices;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesCommon.DI;
using EservicesDomain.ExternalDomain.ERB;
using EservicesDomain.ExternalModel.ERB;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesInfrustructure.Network
{
    public class EmployeeService : IEmployeeService
    {
        private ICoreConfigurations _configuaration => FactoryManager.Instance.Resolve<ICoreConfigurations>();
        private IADServiceD _adService => FactoryManager.Instance.Resolve<IADServiceD>();
        private IRestWrapper _restService => FactoryManager.Instance.Resolve<IRestWrapper>();
        private ILoggerManager logger => FactoryManager.Instance.Resolve<ILoggerManager>();

        public async Task<Employee> GetCurrentUserEmployeeModelAsync(String username)
        {
            var empSvc = new EmployeeServiceClient();
            var result = await empSvc.findByEmailAsync(username.Substring(username.LastIndexOf("\\") + 1) + _configuaration.DomainEmail);
            var theEmp = result.employee;
            Employee emp = GetEmployeeModel(theEmp);
            emp.Username = username;
            return emp;
        }

        public async Task<Employee> FindEmployeeWithEmailAsync(String employeeEmail)
        {
            var response = await _restService.Get<Employee>(_configuaration.ERBWebApiName, $"{_configuaration.ERBEmployeeService}/FindByEmail/{employeeEmail}").ConfigureAwait(false);
            return response;
           
        }

        public async Task<Employee> FindEmployeeWithIDAsync(long employeeID)
        {
            var empSvc = new EmployeeServiceClient();
            var result = await empSvc.findoneAsync(employeeID);
            var theEmp = result.employee;
            return GetEmployeeModel(theEmp);
        }

        public async Task<Employee> FindEmployeeWithKACAREIDAsync(string kacare_id)
        {
            var empSvc = new EmployeeServiceClient();
            var result = await empSvc.findBy_KACARE_IdAsync(kacare_id);
            var theEmp = result.employee;
            return GetEmployeeModel(theEmp);
        }

        public async Task<List<employeeMates>> FindEmployeeDependentsAsync(long employeeID)
        {
            var empSvc = new EmployeeServiceClient();
            var result = await empSvc.findEmployeeMatesAsync(employeeID);
            var mates = result.empmates;
            List<employeeMates> dependents = new List<employeeMates>();

            if (mates == null)
                return dependents;

            foreach (employeeMates oneMate in mates)
            {
                dependents.Add(oneMate);
            }
            return dependents;
        }


        public async Task<List<SelectListItem>> GetVendorsListAsync()
        {
            var empSvc = new EmployeeServiceClient();
            var vendorList = await empSvc.loadAllVendorsAsync();
            List<SelectListItem> vendors = new List<SelectListItem>();
            foreach (vendor oneVendor in vendorList.vendor)
            {
                SelectListItem item = new SelectListItem();
                item.Text = oneVendor.name;
                item.Value = oneVendor.employeeid.ToString();
                vendors.Add(item);
            }

            return vendors.OrderBy(x => x.Text).ToList();
        }


        public async Task<List<SelectListItem>> GetEmployeesListForDelegationAsync(long employeeID)
        {
            var empSvc = new EmployeeServiceClient();
            var result = await empSvc.findAllAsync();
            List<SelectListItem> toBeReturned = new List<SelectListItem>();

            foreach (employee oneEmp in result.employee)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = oneEmp.id.ToString();
                listItem.Text = oneEmp.name;
                toBeReturned.Add(listItem);
            }
            return toBeReturned.OrderBy(x => x.Text).ToList();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var empSvc = new EmployeeServiceClient();
            List<Employee> toBeReturned = new List<Employee>();

            var result = await empSvc.findAllAsync();

            foreach (var emp in result.employee)
                toBeReturned.Add(GetEmployeeModel(emp));

            return toBeReturned;
        }

        public async Task<List<SelectListItem>> GetDepartmentEmployeesAsync(long departmentID)
        {
            var empSvc = new EmployeeServiceClient();

            var result = await empSvc.findByDepartmentAsync(departmentID);

            List<SelectListItem> toBeReturned = new List<SelectListItem>();

            foreach (listItem oneEmp in result.employee)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = oneEmp.id.ToString();
                listItem.Text = oneEmp.text.ToUpper();
                toBeReturned.Add(listItem);
            }
            return toBeReturned.OrderBy(x => x.Text).ToList();
        }


        public async Task<List<Employee>> GetDirectSubordinatesAsync(string empEmail)
        {
            var empSvc = new EmployeeServiceClient();

            var result = await empSvc.findByDirecSubordinatesAsync(empEmail);

            return GetEmployeeModel(result.empdiectsubordinates);
        }

        private List<Employee> GetEmployeeModel(employee[] theEmps)
        {
            List<Employee> employees = new List<Employee>();
            if (theEmps != null)
                foreach (employee single in theEmps)
                    employees.Add(GetEmployeeModel(single));

            return employees;
        }


      
        public async Task<List<Employee>> GetAllSubordinatesAsync(string empEmail)
        {
            var empSvc = new EmployeeServiceClient();
            var result = await empSvc.findByAllSubordinatesAsync(empEmail);
            return GetEmployeeModel(result.empdiectsubordinates);
        }

        public async Task<EmployeeRest> GetEmployeeFromREST(string email)
        {
            var response = await _restService.Get<EmployeeRest>(_configuaration.EmployeeRestServiceName, $"byEmail/{email}").ConfigureAwait(false);
            return response;

        }

        public Employee GetEmployeeModel(employee theEmp)
        {
            Employee theEmpModel = new Employee();

            theEmpModel.Id = theEmp.id;
            theEmpModel.EmpCode = theEmp.empcode;
            theEmpModel.Grade = theEmp.grade;
            theEmpModel.Email = theEmp.email;
            theEmpModel.HireDate = theEmp.hiredate;
            theEmpModel.PassportNo = theEmp.passportno;
            theEmpModel.DefaultAirClass = theEmp.airclasscode;
            theEmpModel.DepartmentManagerEmail = theEmp.deptmanageremail;
            theEmpModel.SupervisorEmail = theEmp.supervisoremail;
            theEmpModel.EmployeeNameAr = theEmp.name;
            theEmpModel.SupervisorNameAr = theEmp.supervisorname;
            theEmpModel.DepartmentManagerAr = theEmp.deptmanagername;
            theEmpModel.DepartmentAr = theEmp.departmentname;
            //theEmpModel.JobTitleAR = theEmp.jobtitlear;
            //theEmpModel.NationalityAR = theEmp.nationality;
            //theEmpModel.SectionNameAR = theEmp.sectionname;
            //theEmpModel.GreetingAR = theEmp.greetingar;

            //theEmpModel.EmployeeNameEN = theEmp.nameeng;
            //theEmpModel.EmployeeManagerEN = theEmp.supervisornameeng;
            //theEmpModel.EmployeeDepartmentManagerEN = theEmp.deptmanagernameeng;
            //theEmpModel.EmployeeDepartmentEN = theEmp.departmentdescription;
            //theEmpModel.JobTitleEN = theEmp.jobtitle;
            //theEmpModel.NationalityEN = theEmp.nationalityar;
            //theEmpModel.SectionNameEN = theEmp.sectiondescription;
            //theEmpModel.GreetingEN = theEmp.greetingen;
            //theEmpModel.Mobile = theEmp.mobile;


            //theEmpModel.EmployeeName = theEmp.name;
            //theEmpModel.EmployeeManager = theEmp.supervisorname;
            //theEmpModel.EmployeeDepartmentManager = theEmp.deptmanagername;
            theEmpModel.EmployeeDepartment = theEmp.departmentname;
            theEmpModel.JobTitle = theEmp.jobtitlear;
            theEmpModel.Nationality = theEmp.nationality;
            theEmpModel.SectionName = theEmp.sectionname;
            theEmpModel.Greeting = theEmp.greetingar;

            theEmpModel.EmployeeName = theEmp.nameeng;
            //theEmpModel.EmployeeManager = theEmp.supervisornameeng;
            //theEmpModel.EmployeeDepartmentManager = theEmp.deptmanagernameeng;
            theEmpModel.EmployeeDepartment = theEmp.departmentdescription;
            theEmpModel.JobTitle = theEmp.jobtitle;
            theEmpModel.Nationality = theEmp.nationalityar;
            theEmpModel.SectionName = theEmp.sectiondescription;
            theEmpModel.Greeting = theEmp.greetingen;

            return theEmpModel;
        }
    }
}
