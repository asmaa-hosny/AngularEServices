using EservicesDomain.Common;


namespace EservicesDomain.Domain.ITCareService
{
    public class ITCareRequest :IEntity<int>
    {
        public long EmployeeId { get; set; }

        public string JobId { get; set; }


    }
}
