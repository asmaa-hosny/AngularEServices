using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.Common
{
    public class DecisionItem
    {
        public string TextAR { get; set; }

        public string TextEN { get; set; }

        public string Value { get; set; }

        public bool CommentsAreMandatory { get; set; }
    }
}
