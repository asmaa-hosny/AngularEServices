
using EServicesWithAngular.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using EServicesWithAngular.Domain.Common;
using EServicesWithAngular.Domain.Commo;
using EServicesWithAngular.DAL;

namespace EServicesWithAngular.Logic
{
    public class RecordsKeepingManager
    {
        public static void addNewHistoricalRecord(string approverId,string jobId,short nodeId,string activityName, string decisionId,string decisionomment )
        {
            using (EServicesDBContext a = new EServicesDBContext())
            {
                CoreApprovals newEntry = new CoreApprovals();

                newEntry.JobId = jobId;
                newEntry.NodeId = nodeId;
                newEntry.Name = approverId;
                newEntry.Role = activityName;
                newEntry.Comment = decisionId;
                newEntry.Notes = decisionomment;
                newEntry.Date = DateTime.Now;

                a.CoreApprovals.Add(newEntry);
                a.SaveChanges();
            }
        }

        private static List<HistoricalRecord> getHistoricalRecordsFromEServicesDB(string jobID)
        {
            List<HistoricalRecord> returned = new List<HistoricalRecord>();
            using (EServicesDBContext a = new EServicesDBContext())
            {
                var histrocialRecords = (from p in a.CoreApprovals where p.JobId.Equals(jobID) select new { p.JobId, p.NodeId, p.Name, p.Role, p.Comment, p.Notes, p.Date }).OrderBy(x => x.Date).ToArray();

                foreach (var oneRecord in histrocialRecords)
                {
                    HistoricalRecord historicalRecord = new HistoricalRecord();

                    historicalRecord.JobID = oneRecord.JobId;
                    historicalRecord.NodeID = (short)oneRecord.NodeId;
                    historicalRecord.Name = oneRecord.Name;
                    historicalRecord.ActivityName = oneRecord.Role;
                    historicalRecord.Action = (from p in a.view_DecisionChoices where p.Lookup_Item_ID.Equals(oneRecord.Comment) select new { p.TextAR, p.TextEN, p.Lookup_Item_ID, p.CommentsMandatory }).ToList().FirstOrDefault().TextEN;
                    historicalRecord.Comment = oneRecord.Notes;
                    historicalRecord.Date = oneRecord.Date;

                    returned.Add(historicalRecord);
                }
            }
            return returned;
        }

        public static WorkflowRecords getWorkflowRecords(string jobid)
        {
            WorkflowRecords recordKeeper = new WorkflowRecords();
            recordKeeper.HistoricalRecords = getHistoricalRecordsFromEServicesDB(jobid);
       
            return recordKeeper;
        }

        private static string retriveDecisionGroupFromActivityHelpText(string helpText)
        {
            if (helpText == null)
                return "";
            JToken data = JObject.Parse(helpText)["DecisionGroup"];
            return data != null ? data.ToString() : "";
        }


        public static List<DecisionItem> getDecisionList(string helpText)
        {
            string decisionGroup = retriveDecisionGroupFromActivityHelpText(helpText);
            List<DecisionItem> returned = new List<DecisionItem>();
            using (EServicesDBContext a = new EServicesDBContext())
            {

                var decisions = !string.IsNullOrEmpty(helpText)?(from p in a.view_DecisionChoices where p.LookupGroup.Equals(decisionGroup) select new { p.TextAR, p.TextEN, p.Lookup_Item_ID, p.CommentsMandatory }).ToArray() : (from p in a.view_DecisionChoices  select new { p.TextAR, p.TextEN, p.Lookup_Item_ID, p.CommentsMandatory }).ToArray();

                foreach (var oneRecord in decisions)
                {
                    DecisionItem oneDecision = new DecisionItem();
                    oneDecision.Value = oneRecord.Lookup_Item_ID;
                    oneDecision.TextAR = oneRecord.TextAR;
                    oneDecision.TextEN = oneRecord.TextEN;
                    oneDecision.CommentsAreMandatory = oneRecord.CommentsMandatory;

                    returned.Add(oneDecision);
                }
            }
            return returned;
        }
    }
}