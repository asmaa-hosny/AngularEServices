using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain
{
    public partial class view_Approvals
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string TextAR { get; set; }
        public string TextEN { get; set; }
        public string Notes { get; set; }
        public string JOB_ID { get; set; }
        public Nullable<short> NodeID { get; set; }
    }
}
