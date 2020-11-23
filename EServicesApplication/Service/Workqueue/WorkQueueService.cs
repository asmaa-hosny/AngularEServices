using CommonLibrary.Logging;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Interfaces.Persistence;
using EServicesCommon.Paging;
using EservicesDomain.Domain.DomainAgility;
using EservicesDomain.ExternalDomain.KTA;
using EservicesDomain.SearchParameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Service.dashboard
{
    public class WorkQueueService : IWorkqueueService
    {
        private IADServiceD _adserviec;
        private IITCareService _itcareService;
        private IAgilityService _agilityService;
        private ILoggerManager _logger;

        public WorkQueueService(IADServiceD adserviec,
            IITCareService itcareService,
            IAgilityService agilityService,ILoggerManager logger)
        {
            _adserviec = adserviec;
            _itcareService = itcareService;
            _agilityService = agilityService;
            _logger = logger;
        }

        public async Task<PagedList<AllRequests>> LoadMyRequests(RequestQueryParameters parameters)
        {
            PagedList<AllRequests> MyRequests = await _agilityService.GetRequests(parameters);
            return MyRequests;
        }

        public async Task<IEnumerable<PassedItems>> LoadITcareRequests(string email)
        {
            IEnumerable<PassedItems> MyRequests=null;
            _logger.LogDebug($"Connect to AD Service and get data for {email}");
            var emp = await _adserviec.GetDataFromAD(email).ConfigureAwait(false);
            if (emp != null)
            {
                _logger.LogDebug($"Connect to ITCare Rest Service and get requests for {email}");
                MyRequests = _itcareService.LoadITCareRequests(emp.FullName);
            }
            return MyRequests;
        }


    }
}
