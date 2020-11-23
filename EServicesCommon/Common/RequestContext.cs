using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesCommon.Common
{
    public class RequestContext
    {
        public Guid ContextId { get; set; }
        public string CallerUsername { get; set; }
        public string UserId { get; set; }
        public string MachineName { get; set; }
        public string IpAddress { get; set; }
        public string Target { get; set; }
        public string ModuleName { get; set; }
        public string Culture { get; set; }
        public string RequestUrl { get; set; }
    }
}
