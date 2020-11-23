
using KTA_UserServices;
using KTA_ResourceServices;
using EServicesWithAngular.DAL.KTA_ActivityServices;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using EServicesWithAngular.Domain.Common;
using EServicesWithAngular.DAL.KTA_JobServices;

namespace EServicesWithAngular.DAL
{
    public static class KtaConnectService
    {
        #region static properties

        static KTA_UserServices.UserServiceClient _usrSvc;

        public static KTA_UserServices.UserServiceClient usrSvc
        {
            get
            {
                return _usrSvc ?? (_usrSvc = new KTA_UserServices.UserServiceClient());
            }
        }

        static KTA_ResourceServices.ResourceServiceClient _resSrvc;

        static KTA_ResourceServices.ResourceServiceClient resSrvc
        {
            get
            {
                return _resSrvc ?? (_resSrvc = new KTA_ResourceServices.ResourceServiceClient());
            }
        }
        static KTA_ActivityServices.ActivityServiceClient _actService;

        static KTA_ActivityServices.ActivityServiceClient actService => _actService ?? (_actService = new KTA_ActivityServices.ActivityServiceClient());
        static KTA_JobServices.JobServiceClient _jobSvc;

        static KTA_JobServices.JobServiceClient JobSvc
        {
            get
            {
                return _jobSvc ?? (_jobSvc = new KTA_JobServices.JobServiceClient());
            }
        }

        #endregion

        public static string LogonUsingWindows(String username)
      {
            UserIdentity2 currentUserIdentity = new UserIdentity2();
            currentUserIdentity.UserId = username;
            currentUserIdentity.LogOnProtocol = 7;

            var usrSession = usrSvc.GetSingleSignOnSessionAsync(StaticClass.Configuration["KTASetting:KTA_SYSTEM_SESSION"], currentUserIdentity).GetAwaiter().GetResult();
            return usrSession.SessionId;
        }

        public static bool validateSession(string sessionid)
        {

            var taskresult = usrSvc.ValidateSessionAsync(sessionid).GetAwaiter().GetResult();
            return taskresult.IsValid;
        }

        public static void AsureResourceExistence(string userName)
        {


            string userFullNam = null;
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                var usr = UserPrincipal.FindByIdentity(context, userName);
                if (usr != null)
                    userFullNam = usr.DisplayName;
            }

            if (!resSrvc.DoesResourceExistAsync(StaticClass.Configuration["KTASetting:KTA_SYSTEM_SESSION"], new KTA_ResourceServices.ResourceIdentity() { Name = userFullNam }).GetAwaiter().GetResult())
            {
                string email = userName.Substring(userName.LastIndexOf("\\") + 1) + "@energy.gov.sa";
                KTA_ResourceServices.ResourceIdentity res = new KTA_ResourceServices.ResourceIdentity();
                res.Name = userFullNam;

                WorkerResource workerRes = new WorkerResource();
                workerRes.EmailAddress = email; workerRes.NTName = userName; workerRes.Identity = res;
                workerRes.Category = new KTA_ResourceServices.CategoryIdentity() { Name = "Default Category" };
                workerRes.WorkingCategory = new KTA_ResourceServices.CategoryIdentity() { Name = "Default Category" };
                workerRes.SkillLevelMin = 10; workerRes.SkillLevelMax = 1; workerRes.SecurityLevel = 1;

                resSrvc.AddWorkerResourceAsync(StaticClass.Configuration["KTASetting:KTA_SYSTEM_SESSION"], workerRes);
            }
        }


        public static List<WorkQueueItem> LoadWorkQueue(string sessionId)
        {
            // Fetch the workqueue

            // Create an activity service and filter

            var actFilter = new JobActivityFilter3();

            actFilter.MaxActivitiesCount = 1000;
            actFilter.UseCombinedWorkQueue = true; //i.e. return individual and group assigned activities


            WorkQueue2 activities = actService.GetWorkQueue2Async(sessionId, actFilter).GetAwaiter().GetResult();

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
            return wqItems;

        }


        public static JobActivity TakeActivity(string sessionId, string jobId, short nodeId, short epc)
        {
            // Create an activity service i.e. can call all methods in the activity service e.g. TakeActivity, Complete, Cancel etc

            // As we are going to take an activity we need to build up the identity of the activity i.e. jobid, node id, embedded process count
            var actIdentity = new KTA_ActivityServices.JobActivityIdentity();

            actIdentity.JobId = jobId;
            actIdentity.NodeId = nodeId;
            actIdentity.EmbeddedProcessCount = epc;

            var jobAct = new JobActivity();

            jobAct = actService.TakeActivityAsync(sessionId, actIdentity).GetAwaiter().GetResult();


            //didn't take activity successfully...e.g. maybe someone else just got it
            //so we'd want to advise the user by providing a message and then returning to workqueue


            return jobAct;
        }

        public static void CompleteActivity(string sessionId, string currentUserId, string decisionId, string decisionComments, KTA_ActivityServices.JobActivityIdentity jobActivity)
        {

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

            actService.CompleteActivityAsync(sessionId, jobActivity, jobActOutput).GetAwaiter().GetResult();
        }


        public static JobActivity OpenActivityInReviewMode(string sessionId, string jobId, short nodeId, short epc)
        {
            JobActivity activity = new JobActivity();
            activity.Identity = new KTA_ActivityServices.JobActivityIdentity();
            activity.Identity.JobId = jobId;
            activity.Identity.NodeId = -1;
            activity.Identity.EmbeddedProcessCount = 0;

            return activity;
        }

        public static void CancelActivity(string sessionId, KTA_ActivityServices.JobActivityIdentity jobActivity)
        {

            actService.CancelActivityAsync(sessionId, jobActivity).GetAwaiter().GetResult();
        }

        public static string CreateJob(string sessionId, string process_ID, long requestNumber, InputVariableCollection inputVarCollection = null)
        {
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


            if (inputVarCollection == null)
            {
                inputVarCollection = new KTA_JobServices.InputVariableCollection();

                // Set up each inputvariable to job (process initialization variables)
                // Must use the ID of the variable in the process, not its display name
                KTA_JobServices.InputVariable id = new KTA_JobServices.InputVariable();
                id.Id = "REQUESTID";
                id.Value = requestNumber;
                inputVarCollection.Add(id);
            }

            // Populate the InputVariables to the job
            jobInit.InputVariables = inputVarCollection;

            // Create the job, passing the session id, process identity and inputvariables. A job identity object containing the job id(string) is returned
            // from the method call
            jobIdentity = jobSvc.CreateJobAsync(sessionId, procIdentity, jobInit).GetAwaiter().GetResult();


            // Return the job id
            return jobIdentity.Id;
        }

        public static KTA_JobServices.InputVariableCollection BuildInputVariableCollection(List<Tuple<string, object>> inputToService)
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

        public static string GetJobCreator(string sessionId, string JobID)
        {
            KTA_JobServices.JobIdentity JobIdentity = new KTA_JobServices.JobIdentity();
            JobIdentity.Id = JobID;
            KTA_JobServices.JobInfo JobInfo = new KTA_JobServices.JobInfo();
            KTA_JobServices.JobHistoryFilter Filter = new KTA_JobServices.JobHistoryFilter();
            var jobSvc = new KTA_JobServices.JobServiceClient();
            JobInfo = jobSvc.GetJobInfoAsync(sessionId, JobIdentity, Filter).GetAwaiter().GetResult();
            return JobInfo.Creator.Name;
        }



    }
}
