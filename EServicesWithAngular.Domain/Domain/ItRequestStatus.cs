using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Request_Status")]
    public class ItRequestStatus
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("Assignment ID")]
        public int AssignmentId { get; private set; }
        [Required]
        [StringLength(10)]
        public string Text { get; private set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; private set; }
        [Required]
        [StringLength(50)]
        public string Username { get; private set; }

        [ForeignKey("AssignmentId")]
        [InverseProperty("ItRequestStatus")]
        public ItRepositoryAssignment Assignment { get; private set; }
    }
}
