using ERP_EmployeeServices;
using EservicesDomain.ExternalDomain.ERB;
using EservicesDomain.ExternalModel.ERB;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Infrastructure
{
    public interface IEmployeeService
    {
        Task<Employee> GetCurrentUserEmployeeModelAsync(String username);

        Task<Employee> FindEmployeeWithEmailAsync(String employeeEmail);

        Task<Employee> FindEmployeeWithIDAsync(long employeeID);

        Task<Employee> FindEmployeeWithKACAREIDAsync(string kacare_id);

        Task<List<employeeMates>> FindEmployeeDependentsAsync(long employeeID);

        Task<List<SelectListItem>> GetVendorsListAsync();

        Task<List<SelectListItem>> GetEmployeesListForDelegationAsync(long employeeID);

        Task<List<Employee>> GetAllEmployeesAsync();

        Task<List<SelectListItem>> GetDepartmentEmployeesAsync(long departmentID);

        Task<List<Employee>> GetDirectSubordinatesAsync(string empEmail);

        Task<List<Employee>> GetAllSubordinatesAsync(string empEmail);

        Task<EmployeeRest> GetEmployeeFromREST(string email);


    }
}
