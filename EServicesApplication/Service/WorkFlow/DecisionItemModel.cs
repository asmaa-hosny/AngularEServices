using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesApplication.Services.WorkFlow
{
    public class DecisionItemModel
    {
        public string TextAR { get; set; }

        public string TextEN { get; set; }

        public string Value { get; set; }

        public bool CommentsAreMandatory { get; set; }
    }
}
