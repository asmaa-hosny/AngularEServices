using EServicesCommon.Paging;


namespace EservicesDomain.ExternalDomain.UAC
{
    public class FellowQueryModel : QueryParameters
    {
        public int UniversityId { get; set; }

        public bool Publication { get; set; } = false;
    }
}
