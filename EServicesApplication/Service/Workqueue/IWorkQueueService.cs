using EServicesCommon.Paging;
using EservicesDomain.Domain.DomainAgility;
using EservicesDomain.ExternalDomain.KTA;
using EservicesDomain.SearchParameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Service.dashboard
{
    public interface IWorkqueueService
    {
        Task<PagedList<AllRequests>> LoadMyRequests(RequestQueryParameters parameter);

        Task<IEnumerable<PassedItems>> LoadITcareRequests(string email);
    }
}
