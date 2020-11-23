
using System.Collections.Generic;


namespace EservicesDomain.ExternalDomain.ITCare
{
    public class ResultInfo
    {
        public string subject { get; set; }
        public string short_description { get; set; }
        public Dictionary<string, string> created_by { get; set; }
        public Dictionary<string, string> site { get; set; }
        public Dictionary<string, string> created_time { get; set; }
        public Dictionary<string, string> requester { get; set; }
        public string id { get; set; }
        public Dictionary<string, string> status { get; set; }

    }
}
