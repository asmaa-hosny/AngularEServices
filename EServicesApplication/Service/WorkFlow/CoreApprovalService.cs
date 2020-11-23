using EServicesApplication.Services.WorkFlow.Services;
using EservicesDomain.Domain.Workflow;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EServicesApplication.Interfaces.Persistence;

namespace EServicesApplication.Services.WorkFlow
{
    public class CoreApprovalService : BaseService<CoreApproval, int>, ICoreApprovalService
    {
        private IRepository<DecisionChoices, int> _decisionRepository;
        public CoreApprovalService(IRepository<DecisionChoices,int> decisionRepository )
        {
            _decisionRepository = decisionRepository;
        }

        public async Task addCoreApprovals(string approverId, string jobId, short nodeId, string activityName, string decisionId, string decisionomment)
        {
            var approval = CoreApproval.Create(jobId, activityName, name: approverId, date: DateTime.Now, comment: decisionId, nodeId: nodeId, notes: decisionomment);
            await AddNewRequest(approval);
        }


        public List<HistoricalRecord> GetApprovalHistory(string jobID)
        {
            var result =  this.Find(x => x.JobId == jobID);
            
            var MappedResult = this.Mapper.Map<List<HistoricalRecord>>(result);

            foreach (var item in MappedResult)
            {
                var itemDecision =_decisionRepository.GetQurable().Where(x => x.Lookup_Item_ID == item.DecisionId).FirstOrDefault();
                if (itemDecision != null) item.Action = itemDecision.TextEN;
            }
            return MappedResult;
        }

    }
}
