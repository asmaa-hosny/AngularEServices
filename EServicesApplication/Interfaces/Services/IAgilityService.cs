using EServicesCommon.Paging;
using EservicesDomain.Domain.DomainAgility;
using EservicesDomain.ExternalDomain.KTA;
using EservicesDomain.SearchParameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Persistence
{
    public interface IAgilityService
    {
        Task<List<PassedItems>> GetCompletedTasksByResource(string userEmail, string refid, string resourceEmail, DateTime? fromDate, DateTime? toDate);

        Task<PagedList<AllRequests>> GetRequests(RequestQueryParameters parameter);
    }
}
