using System;


namespace EServicesApplication.Services.WorkFlow
{
    public class HistoricalRecord
    {
     
        public string JobID { get; set; }
        public int NodeID { get; set; }
        public int EPC { get; set; }
        public string ActivityName { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Action { get; set; }
        public string Comment { get; set; }
        public string DecisionId { get; set; }

    }
}
