using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.Common
{
    public partial class STATISTICS_GetRequestsReleatedToUser_Result
    {
        public byte[] JOB_ID { get; set; }
        public string PROCESS_NAME { get; set; }
        public string REF_ID { get; set; }
        public string requestor { get; set; }
        public string requestorEmail { get; set; }
        public string currentLocation { get; set; }
        public System.DateTime CREATION_TIME { get; set; }
        public string ASSOCIATED_FILE { get; set; }
    }
}
