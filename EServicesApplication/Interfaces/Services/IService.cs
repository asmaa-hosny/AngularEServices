using EServicesApplication.Services.Common;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Services
{
    public interface IService<T>
    {

        Task<T> GetRequestData(RequestDataModel data);

        Task<T> ReviewRequestData(RequestDataModel data);

        Task<T> SaveRequestData(T dto);

        Task<T> ProcessRequest(T dto);

    }
}
