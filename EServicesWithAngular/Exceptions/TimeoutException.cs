using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Exceptions
{
    public class TimeoutException : CustomException
    {
        public new string FriendlyMsgAR => "تم إنهاء الجلسة بسبب عدم التفاعل مع الصفحة. الرجاء تحديث الصفحة والبدء من جديد.";
        public new string FriendlyMsgEN => "You have exceeded the alotted time for the session. Please refresh the page.";
    }
}
