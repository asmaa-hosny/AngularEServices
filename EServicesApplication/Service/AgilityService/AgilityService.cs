using EServicesApplication.Interfaces.Persistence;
using EservicesDomain.Domain.DomainAgility;
using EservicesDomain.ExternalDomain.KTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EServicesCommon.DI;
using AutoMapper;
using EServicesCommon.Paging;
using CommonLibrary.Configuaration;
using EservicesDomain.SearchParameters;

namespace EServicesApplication.AgilityService
{

    public class AgilityBaseService : IAgilityService
    {
        private IAgilityRepository<CompletedTasks, int> _completedTasksRepository;
        private IAgilityRepository<AllRequests, int> _requestsRepository;
        private ICoreConfigurations _configuaration;
        private IMapper _mapper;

        public AgilityBaseService(IAgilityRepository<CompletedTasks, int> completedTasksRepository,
            IAgilityRepository<AllRequests, int> requestsRepository, IMapper mapper,
             ICoreConfigurations configuaration)
        {
            _completedTasksRepository = completedTasksRepository;
            _requestsRepository = requestsRepository;
            _configuaration = configuaration;
            _mapper = mapper;
        }

        private IMapper Mapper => FactoryManager.Instance.Resolve<IMapper>();

        public async Task<PagedList<AllRequests>> GetRequests(RequestQueryParameters parameters)
        {

            var orderedList = _requestsRepository.GetDbSet().OrderBy(parameters.OrderBy).AsQueryable();

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
                orderedList = orderedList.Where(x => x.PROCESS_NAME.Contains(parameters.SearchQuery) ||
                x.REF_ID.Contains(parameters.SearchQuery) || x.JOB_STATUS.Contains(parameters.SearchQuery) 
                || x.JOB_STATUS.Contains(parameters.SearchQuery) || x.CurrentStage.Contains(parameters.SearchQuery));

            if (!string.IsNullOrEmpty(parameters.ProcessName))
                orderedList = orderedList.Where(x => x.PROCESS_NAME.Contains(parameters.ProcessName));

            if (!string.IsNullOrEmpty(parameters.REF_ID))
                orderedList = orderedList.Where(x => x.REF_ID.Contains(parameters.REF_ID));

            if (!string.IsNullOrEmpty(parameters.JOB_STATUS))
                orderedList = orderedList.Where(x => x.JOB_STATUS.Contains(parameters.JOB_STATUS));

            if (!string.IsNullOrEmpty(parameters.CurrentStage))
                orderedList = orderedList.Where(x => x.CurrentStage.Contains(parameters.CurrentStage));

            if (!string.IsNullOrEmpty(parameters.UserEmail))
                orderedList = orderedList.Where(x => x.EMP_EMAIL == parameters.UserEmail);

            if (parameters.FromDate.HasValue)
                orderedList = orderedList.Where(x => x.Request_Date <= parameters.FromDate);

            if (parameters.ToDate.HasValue)
                orderedList = orderedList.Where(x => x.Request_Date <= parameters.FromDate);

            var pagedList = await PagedList<AllRequests>.Create(orderedList, parameters.PageNumber, parameters.PageSize);

            return pagedList;
        }

        public async Task<List<PassedItems>> GetCompletedTasksByResource(string userEmail, string refid = null, string resourceEmail = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _completedTasksRepository.GetQurable();

            if (!string.IsNullOrEmpty(userEmail))
                query = query.Where(x => x.ActionMakerEmail == userEmail);
            if (refid != null)
                query = query.Where(item => item.REF_ID == refid);
            if (resourceEmail != null)
                query = query.Where(item => item.requestorEmail == resourceEmail);
            if (fromDate.HasValue)
                query = query.Where(item => item.CREATION_TIME >= fromDate.Value);
            if (toDate.HasValue)
                query = query.Where(item => item.CREATION_TIME <= toDate.Value);

            query = query.OrderByDescending(x => x.CREATION_TIME);

            var requests = await query.ToListAsync(); ;

            var result = _mapper.Map<List<PassedItems>>(requests);

            return result;
        }




    }
}

