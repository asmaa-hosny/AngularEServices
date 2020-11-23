using EservicesDomain.Common;
using System;

using System.ComponentModel.DataAnnotations;


namespace EservicesDomain.Domain.Workflow
{
    public class CoreApproval : IKtaEntity<int>
    {
        [Required]
        public string Role { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public string Comment { get; set; }

        public string Notes { get; set; }

        

        public static CoreApproval Create( string jobId, string role, string name, DateTime? date, string comment, short nodeId,string notes)
        {
            return new CoreApproval()
            {
                JobId = jobId,
                Role = role,
                Name = name,
                Date = date,
                Comment = comment,
                NodeID = nodeId,
                Notes = notes
            };
        }
    }
}
