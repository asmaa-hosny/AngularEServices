using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Request")]
    public class ItRequest
    {
        public ItRequest()
        {
            ItRepositoryAssignment = new HashSet<ItRepositoryAssignment>();
            ItRequestContractor = new HashSet<ItRequestContractor>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(13)]
        public string RefId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Column("Return Date", TypeName = "date")]
        public DateTime? ReturnDate { get; private set; }
        [StringLength(1000)]
        public string Notes { get; private set; }
        [Required]
        [StringLength(1000)]
        public string Justification { get; private set; }
        [Required]
        [StringLength(10)]
        public string Beneficiary { get; private set; }

        [InverseProperty("Request")]
        public ICollection<ItRepositoryAssignment> ItRepositoryAssignment { get; private set; }
        [InverseProperty("ItRequest")]
        public ICollection<ItRequestContractor> ItRequestContractor { get; private set; }
    }
}
