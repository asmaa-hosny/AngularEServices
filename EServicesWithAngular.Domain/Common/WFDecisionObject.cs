using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain.Common
{
    public class WFDecisionObject
    {

        public int  Id { get; set; }
            
        public string JobId { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Action { get; set; }

        public string Comments { get; set; }

        public string ActivityName { get; set; }

        public short? NodeId { get; set; }

        public bool CommentsMandatory { get; set; }
    }
}