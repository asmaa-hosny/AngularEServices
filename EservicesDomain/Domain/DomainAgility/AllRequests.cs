using System;


namespace EservicesDomain.Domain.DomainAgility
{
    public partial class AllRequests
    {
        public byte[] JOB_ID { get; set; }
        public string PROCESS_NAME { get; set; }
        public byte[] PROCESS_ID { get; set; }
        public string REF_ID { get; set; }
        public DateTime Request_Date { get; set; }
        public string Employee_Name { get; set; }
        public string CurrentStage { get; set; }
        public string JOB_STATUS { get; set; }
        public short JOB_STATUS_INT { get; set; }
        public string EMP_EMAIL { get; set; }
        public string ASSOCIATED_FILE { get; set; }
        public DateTime Job_Finish_Time { get; set; }
        public string ParentCategoryName { get; set; }
    }
}
