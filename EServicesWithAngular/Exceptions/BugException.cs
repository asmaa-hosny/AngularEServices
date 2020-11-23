using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Exceptions
{
    public class BugException : CustomException
    {
        public string Username { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public object HelpfullInfo { get; set; }
        public List<string> Changes { get; set; }
        public new string FriendlyMsgAR => "حصل خطأ في النظام وتم إبلاغ الفريق المختص.";
        public new string FriendlyMsgEN => "Something went wrong and the team was reported.";
    }
}