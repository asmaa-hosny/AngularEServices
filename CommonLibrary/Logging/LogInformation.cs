using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Logging
{

    public class LogInformation
    {
        public string Message { get; set; }

        public string ClassName { get; set; }

        public string NameSpace { get; set; }

        public string MethodCaller { get; set; }

        public Exception exception { get; set; }

        public string Level { get; set; }

        public string CreatedBy { get; set; } // Not Yet

        public string CurrentPageUrl { get; set; } //Not Yet

        public Guid ContextId { get; set; }
    }

}
