using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("Core_Approvals")]
    public class CoreApprovals
    {
        [Column("ID")]
        public int Id { get;  set; }
        [Required]
        [Column("JOB ID")]
        [StringLength(50)]
        public string JobId { get;  set; }
        [Required]
        [StringLength(50)]
        public string Role { get;  set; }
        [Required]
        [StringLength(50)]
        public string Name { get;  set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get;  set; }
        [Required]
        [StringLength(50)]
        public string Comment { get;  set; }
        public string Notes { get;  set; }
        [Column("NodeID")]
        public short? NodeId { get;  set; }

        public static CoreApprovals Create(int id ,string jobId, string role, string name, DateTime? date, string comment, short? nodeId)
        {
            return new CoreApprovals()
            {
                Id = id,
                JobId = jobId,
                Role = role,
                Name = name,
                Date = date,
                Comment = comment,
                NodeId = nodeId
            };
        }
    }
}
