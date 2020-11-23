using EServicesCommon.Paging;
using EservicesDomain.Domain.DomainAgility;
using EservicesDomain.SearchParameters;

using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Persistence
{
    public interface IAgilityRepository<T, Tid> : IRepository<T, Tid> where T : class
    {
       
    }
}
