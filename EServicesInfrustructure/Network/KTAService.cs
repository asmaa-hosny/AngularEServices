using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using EservicesDomain.ExternalModel.KTA;
using KTA_JobServices;
using KTA_UserServices;
using KTA_ResourceServices;
using KTA_ActivityServices;
using EServicesApplication.Interfaces.Infrastructure;

using EServicesCommon.DI;
using System.Threading.Tasks;

using CommonLibrary.Configuaration;
using EServicesApplication.Services.WorkFlow.Services;
using CommonLibrary.Logging;
using System.Linq;

namespace EServicesInfrustructure.Network
{
    public class KTAService : IKTAService
    {
        public ILoggerManager logger = FactoryManager.Instance.Resolve<ILoggerManager>();
        #region  properties
        private ICoreConfigurations _config
        {
            get
            {
                return FactoryManager.Instance.Resolve<ICoreConfigurations>();
            }
        }

        private ICoreApprovalService _coreApprovalService
        {
            get
            {
                return FactoryManager.Instance.Resolve<ICoreApprovalService>();
            }
        }



        #endregion

        public async Task<string> LogonUsingWindowsAsync(String username)
        {
            var usrSvc = new KTA_UserServices.UserServiceClient();
            UserIdentity2 currentUserIdentity = new UserIdentity2();
            currentUserIdentity.UserId = username;
            currentUserIdentity.LogOnProtocol = 7;
            var usrSession = await usrSvc.GetSingleSignOnSessionAsync(_config.KTA_SYSTEM_SESSION, currentUserIdentity);
            await usrSvc.CloseAsync();
            return usrSession.SessionId;
        }

        public async Task<bool> ValidateSessionAsync(string sessionid)
        {
            var usrSvc = new KTA_UserServices.UserServiceClient();
            var taskresult = await usrSvc.ValidateSessionAsync(sessionid);
            await usrSvc.CloseAsync();
            return taskresult.IsValid;
        }

        public async Task AsureResourceExistenceAsync(string userName)
        {
            var resSrvc = new KTA_ResourceServices.ResourceServiceClient();
            string userFullNam = string.Empty;
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                var usr = UserPrincipal.FindByIdentity(context, userName);
                if (usr != null)
                    userFullNam = usr.DisplayName;
            }
            var exist = await resSrvc.DoesResourceExistAsync(_config.KTA_SYSTEM_SESSION, new KTA_ResourceServices.ResourceIdentity() { Name = userFullNam });
            if (!exist)
            {
                string email = userName.Substring(userName.LastIndexOf("\\") + 1) + _config.DomainEmail;
                KTA_ResourceServices.ResourceIdentity res = new KTA_ResourceServices.ResourceIdentity();
                res.Name = userFullNam;

                WorkerResource workerRes = new WorkerResource();
                workerRes.EmailAddress = email; workerRes.NTName = userName; workerRes.Identity = res;
                workerRes.Category = new KTA_ResourceServices.CategoryIdentity() { Name = "Default Category" };
                workerRes.WorkingCategory = new KTA_ResourceServices.CategoryIdentity() { Name = "Default Category" };
                workerRes.SkillLevelMin = 10; workerRes.SkillLevelMax = 1; workerRes.SecurityLevel = 1;

                await resSrvc.AddWorkerResourceAsync(_config.KTA_SYSTEM_SESSION, workerRes);
                await resSrvc.CloseAsync();
            }
        }


        public async Task<List<WorkQueueItem>> LoadWorkQueueAsync(string sessionId)
        {
            // Fetch the workqueue

            // Create an activity service and filter
            var actService = new KTA_ActivityServices.ActivityServiceClient();
            var actFilter = new JobActivityFilter3();

            actFilter.MaxActivitiesCount = 1000;
            actFilter.UseCombinedWorkQueue = true; //i.e. return individual and group assigned activities

            WorkQueue2 activities = await actService.GetWorkQueue2Async(sessionId, actFilter);

            // Get the activity summary collection i.e. we are just getting activity information for display in the workqueue
            var jobActSumCol = activities.JobActivitySummary2Collection;


            // test if no items in workqueue???

            var wqItems = new List<WorkQueueItem>();
         
            foreach (var item in jobActSumCol)
            {
                var wqItem = new WorkQueueItem();
                wqItem.JobSLA = item.JobSlaStatus.ImagePath;
                wqItem.ProcessName = item.Process.Name;
                wqItem.ActivitySLA = item.ActivitySlaStatus.ImagePath;
                wqItem.ActivityName = item.ActivityIdentity.ActivityName;
                wqItem.DueDate = item.DueDateTime;
                wqItem.AssignedTo = item.Resource.Name;
                wqItem.EmployeeName = (string)item.Fields[1].Value;
                wqItem.REF_ID = (string)item.Fields[0].Value;
                wqItem.JobId = item.ActivityIdentity.JobId;
                wqItem.NodeId = item.ActivityIdentity.NodeId;
                wqItem.EPC = item.ActivityIdentity.EmbeddedProcessCount;
                wqItem.AssociatedFile = item.AssociatedFile;

                wqItems.Add(wqItem);
                

            }
         
            wqItems.Reverse();

            await actService.CloseAsync();
            return wqItems;

        }


        public async Task<JobActivity> TakeActivityAsync(string sessionId, string jobId, short nodeId, short epc)
        {
            var _actService = new KTA_ActivityServices.ActivityServiceClient();
            // Create an activity service i.e. can call all methods in the activity service e.g. TakeActivity, Complete, Cancel etc

            // As we are going to take an activity we need to build up the identity of the activity i.e. jobid, node id, embedded process count
            var actIdentity = new KTA_ActivityServices.JobActivityIdentity();

            actIdentity.JobId = jobId;
            actIdentity.NodeId = nodeId;
            actIdentity.EmbeddedProcessCount = epc;

            var jobAct = new JobActivity();

            var result = await _actService.TakeActivityAsync(sessionId, actIdentity);
            await _actService.CloseAsync();
            return result;

        }

        public async Task CompleteActivityAsync(string sessionId, string currentUserId, string decisionId, string decisionComments, KTA_ActivityServices.JobActivityIdentity jobActivity)
        {
            var actService = new KTA_ActivityServices.ActivityServiceClient();

            var jobActOutput = new JobActivityOutput();
            KTA_ActivityServices.OutputVariableCollection outputVariables = new KTA_ActivityServices.OutputVariableCollection();
            KTA_ActivityServices.OutputVariable temp = new KTA_ActivityServices.OutputVariable();

            temp.Id = "ZZZ__LATESTAPPROVAL_APPROVER_N"; temp.Value = currentUserId;
            outputVariables.Add(temp);
            temp = new KTA_ActivityServices.OutputVariable();
            temp.Id = "ZZZ__LATESTAPPROVAL_APPROVER_C"; temp.Value = decisionComments;
            outputVariables.Add(temp);
            temp = new KTA_ActivityServices.OutputVariable();
            temp.Id = "ZZZ__LATESTAPPROVAL_DECISION_D"; temp.Value = DateTime.Now;
            outputVariables.Add(temp);
            temp = new KTA_ActivityServices.OutputVariable();
            temp.Id = "ZZZ__LATESTDECISION"; temp.Value = decisionId;
            outputVariables.Add(temp);

            jobActOutput.OutputVariables = outputVariables;

            await _coreApprovalService.addCoreApprovals(
                currentUserId, jobActivity.JobId, jobActivity.NodeId,
                jobActivity.ActivityName, decisionId, decisionComments);

            await actService.CompleteActivityAsync(sessionId, jobActivity, jobActOutput);

            await actService.CloseAsync();


        }

        public JobActivity OpenActivityInReviewMode(string sessionId, string jobId, short nodeId, short epc)
        {
            JobActivity activity = new JobActivity();
            activity.Identity = new KTA_ActivityServices.JobActivityIdentity();
            activity.Identity.JobId = jobId;
            activity.Identity.NodeId = -1;
            activity.Identity.EmbeddedProcessCount = 0;

            return activity;
        }

        public async Task CancelActivityAsync(string sessionId, KTA_ActivityServices.JobActivityIdentity jobActivity)
        {
            var actService = new KTA_ActivityServices.ActivityServiceClient();
            await actService.CancelActivityAsync(sessionId, jobActivity);
            await actService.CloseAsync();

        }

        public async Task<string> CreateJobAsync(string sessionId, string process_ID, long requestNumber, InputVariableCollection inputVarCollection = null)
        {
            logger.LogDebug($"CreateJobAsync requestNumber fired {requestNumber}");
            // Set up the create new job method
            // Create a job service client so we call the methods in the job service e.g. createjob etc

            var jobSvc = new KTA_JobServices.JobServiceClient();


            // Set up variables for the CreateJob method. Create job requires sessionid, process identity, and process initialization variables (input variables)
            // CreateJob method returns the Job Identity (Job Id).
            var procIdentity = new KTA_JobServices.ProcessIdentity();

            var jobInit = new KTA_JobServices.JobInitialization();


            // These variables are used for the return object (job identity)
            var jobIdentity = new KTA_JobServices.JobIdentity();


            // This is the process identity of the Loan Application API process. This Id was obtained by running a select * from the Business_Process table
            procIdentity.Id = process_ID;
            logger.LogDebug($"procIdentity.Id {procIdentity.Id}");



            if (inputVarCollection == null)
            {
                inputVarCollection = new KTA_JobServices.InputVariableCollection();

                // Set up each inputvariable to job (process initialization variables)
                // Must use the ID of the variable in the process, not its display name
                KTA_JobServices.InputVariable id = new KTA_JobServices.InputVariable();
                logger.LogDebug($"KTA_JobServices.InputVariable id  {id.Id}");

                id.Id = "REQUESTID";
                id.Value = requestNumber;
                inputVarCollection.Add(id);
            }

            // Populate the InputVariables to the job
            jobInit.InputVariables = inputVarCollection;


            // Create the job, passing the session id, process identity and inputvariables. A job identity object containing the job id(string) is returned
            // from the method call
            jobIdentity = await jobSvc.CreateJobAsync(sessionId, procIdentity, jobInit);
            logger.LogDebug($"Create Job Identity jobId fired {jobIdentity.Id}");

            // Return the job i
            return jobIdentity.Id;
        }

        public KTA_JobServices.InputVariableCollection BuildInputVariableCollection(List<Tuple<string, object>> inputToService)
        {
            KTA_JobServices.InputVariableCollection inputVarCollection = new KTA_JobServices.InputVariableCollection();

            foreach (Tuple<string, object> oneInput in inputToService)
            {
                KTA_JobServices.InputVariable inputVariable = new KTA_JobServices.InputVariable();
                inputVariable.Id = oneInput.Item1;
                inputVariable.Value = oneInput.Item2;
                inputVarCollection.Add(inputVariable);
            }

            return inputVarCollection;
        }

        public async Task<string> GetJobCreatorAsync(string sessionId, string JobID)
        {
            KTA_JobServices.JobIdentity JobIdentity = new KTA_JobServices.JobIdentity();
            JobIdentity.Id = JobID;
            KTA_JobServices.JobInfo JobInfo = new KTA_JobServices.JobInfo();
            KTA_JobServices.JobHistoryFilter Filter = new KTA_JobServices.JobHistoryFilter();
            var jobSvc = new KTA_JobServices.JobServiceClient();
            JobInfo = await jobSvc.GetJobInfoAsync(sessionId, JobIdentity, Filter);
            return JobInfo.Creator.Name;
        }



    }
}
