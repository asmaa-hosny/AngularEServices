using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.Domain.Workflow
{
    public class DecisionChoices : IEntity<int>
    {
        public string Lookup_Item_ID { get; set; }
        public string TextAR { get; set; }
        public string TextEN { get; set; }
        public string LookupGroup { get; set; }
        public bool CommentsMandatory { get; set; }
    }
}
