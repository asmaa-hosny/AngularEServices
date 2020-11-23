using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Services.WorkFlow.Services
{
    public interface  ICoreApprovalService
    {
        Task addCoreApprovals(string approverId, string jobId, short nodeId, string activityName, string decisionId, string decisionomment);

        List<HistoricalRecord> GetApprovalHistory(string jobID);
    }
}