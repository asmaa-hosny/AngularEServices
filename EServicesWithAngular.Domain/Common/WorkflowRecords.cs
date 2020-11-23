using EServicesWithAngular.Domain.Commo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.Common
{
    public class WorkflowRecords
    {
        public WorkflowRecords()
        {
            HistoricalRecords = new List<HistoricalRecord>();
        }
        public List<HistoricalRecord> HistoricalRecords { get; set; }
    }
}
