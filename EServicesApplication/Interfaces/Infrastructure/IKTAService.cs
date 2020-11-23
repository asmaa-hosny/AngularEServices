using System;
using System.Collections.Generic;
using KTA_JobServices;
using KTA_ActivityServices;
using EservicesDomain.ExternalModel.KTA;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Infrastructure
{
    public interface IKTAService
    {
        Task<string> GetJobCreatorAsync(string sessionId, string JobID);

        InputVariableCollection BuildInputVariableCollection(List<Tuple<string, object>> inputToService);

        Task<string> CreateJobAsync(string sessionId, string process_ID, long requestNumber, InputVariableCollection inputVarCollection = null);

        Task CancelActivityAsync(string sessionId, KTA_ActivityServices.JobActivityIdentity jobActivity);

        JobActivity OpenActivityInReviewMode(string sessionId, string jobId, short nodeId, short epc);

        Task CompleteActivityAsync(string sessionId, string currentUserId, string decisionId, string decisionComments, KTA_ActivityServices.JobActivityIdentity jobActivity);

        Task<JobActivity> TakeActivityAsync(string sessionId, string jobId, short nodeId, short epc);

        Task<List<WorkQueueItem>> LoadWorkQueueAsync(string sessionId);

        Task AsureResourceExistenceAsync(string userName);

        Task<bool> ValidateSessionAsync(string sessionid);

        Task<string> LogonUsingWindowsAsync(String username);
    }
}
