using System.Threading.Tasks;
using EservicesDomain.ExternalModel.ERB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace EServicesWithAngular.Controllers
{
    public class EmployeeController : BaseController
    {

        [HttpGet("getCurrentEmployee")]
        public async Task<IActionResult> getCurrentEmployee(bool getAD = false)
        {
            // if(this.HostingEnvironment.EnvironmentName== Environments.Development)
            if (CurrentUser== "ENERGY\\d.khudairi.c" || CurrentUser == "ENERGY\\r.draiwaish.c")
            {
                getAD = true;
            }
            Employee employeedata = new Employee();
            try
            {
                employeedata = await EmployeeService.FindEmployeeWithEmailAsync(CurrentUserEmail);
            }
            catch {
                Logger.LogDebug($"can not get data for this email : {CurrentUserEmail}");
            }
            if (getAD)
            {
                var ademployee = await ADService.GetDataFromAD(CurrentUserEmail);
                var employee = Mapper.Map<Employee>(ademployee);
                Mapper.Map<ADService.ADReturned, Employee>(ademployee, employeedata);
                employeedata.Email = CurrentUserEmail;
            }
            return Ok(employeedata);

        }




    }
}