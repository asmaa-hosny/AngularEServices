using System;


namespace EservicesDomain.ExternalDomain.KTA
{
    public class PassedItems
    {
        public string Temp_JOB_ID { get; set; }
        public byte[] BinaryJOBID { get; set; }
        public string JOB_ID { get; set; }
        public string ProcessName { get; set; }
        public string REF_ID { get; set; }
        public string Requestor { get; set; }
        public string Email { get; set; }
        public string CurrentLocation { get; set; }
        public string AssociatedFile { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public string Short_description { get; set; }
    }

    public class AllRequestPassedItem
    {
        public string Temp_JOB_ID { get; set; }
        public byte[] BinaryJOBID { get; set; }
        public string JOB_ID { get; set; }
        public string PROCESS_NAME { get; set; }
        public string REF_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Email { get; set; }
        public string CurrentStage { get; set; }
        public string AssociatedFile { get; set; }
        public DateTime Request_Date { get; set; }
        public string JOB_STATUS { get; set; }
    }
}
