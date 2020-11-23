using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
   
    public class Decision : BaseEntity<int>
    {
        public string JobId { get;  set; }
     
        public string Role { get;  set; }
      
        public string Name { get;  set; }
     
        public DateTime? Date { get;  set; }
    
        public string Comment { get;  set; }
   
        public short? NodeId { get;  set; }


        public static Decision Create(int id,string jobId, string role, string name, DateTime? date, string comment, short? nodeId)
        {
            return new Decision()
            {
                Id=id,
                JobId = jobId,
                Role = role,
                Name = name,
                Date = date,
                Comment = comment,
                NodeId=nodeId
            };
        }
        public static implicit operator CoreApprovals(Decision decision)
        {
            return CoreApprovals.Create(decision.Id,decision.Role, decision.JobId, decision.Name, decision.Date,
                decision.Comment, decision.NodeId);
        }

        public static implicit operator Decision(CoreApprovals decision)
        {
            return Decision.Create(decision.Id, decision.Role, decision.JobId, decision.Name, decision.Date,
                decision.Comment, decision.NodeId);
        }
    }
}
