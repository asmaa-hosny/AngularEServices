
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Exceptions
{
    public class CustomException : Exception
    {
        public string FriendlyMsgAR { get; set; }
        public string FriendlyMsgEN { get; set; }
    }
}
