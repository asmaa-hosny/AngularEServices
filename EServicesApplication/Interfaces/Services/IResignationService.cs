using EServicesApplication.Services.Resignation;
using EservicesDomain.ExternalModel.ERB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Services
{
    public interface IResignationService : IService<ITResignationDTO>
    {

        List<ITResignationStatusModel> GetItems(short nodeId);

        Task<Employee> GetResignedEmployeeData(string email);


    }
}
