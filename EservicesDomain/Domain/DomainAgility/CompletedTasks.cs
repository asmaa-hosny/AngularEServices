using System;


namespace EservicesDomain.Domain.DomainAgility
{
    public class CompletedTasks
    {
        public string ActionMakerEmail { get; set; }
        public byte[] JOB_ID { get; set; }
        public string PROCESS_NAME { get; set; }
        public string REF_ID { get; set; }
        public string requestor { get; set; }
        public string requestorEmail { get; set; }
        public string currentLocation { get; set; }
        public DateTime CREATION_TIME { get; set; }
        public string ASSOCIATED_FILE { get; set; }
    }
}
