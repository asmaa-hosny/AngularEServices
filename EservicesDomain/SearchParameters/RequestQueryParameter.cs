using EServicesCommon.Paging;


namespace EservicesDomain.SearchParameters
{
    public class RequestQueryParameters : QueryParameters
    {
        public string ProcessName { get; set; }

        public string REF_ID { get; set; }

        public string AssociatedFile { get; set; }

        public string JOB_STATUS { get; set; }

        public string CurrentStage { get; set; }

    }
}
