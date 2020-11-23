using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.Commo
{
    public class HistoricalRecord
    {
        public HistoricalRecord()
        { }

        public HistoricalRecord(string jobID, int nodeID, int epc, string activityName, string name, DateTime date, string action, string comment)
        {
            JobID = jobID;
            NodeID = nodeID;
            EPC = epc;
            ActivityName = activityName;
            Name = name;
            Date = date;
            Action = action;
            Comment = comment;
        }

        public string JobID { get; set; }
        public int NodeID { get; set; }
        public int EPC { get; set; }
        public string ActivityName { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        public string Action { get; set; }
        public string Comment { get; set; }

    }
}