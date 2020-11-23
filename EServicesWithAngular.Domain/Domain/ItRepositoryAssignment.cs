using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Repository_Assignment")]
    public class ItRepositoryAssignment
    {
        public ItRepositoryAssignment()
        {
            ItRequestStatus = new HashSet<ItRequestStatus>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("Product ID")]
        public int ProductId { get; private set; }
        [Column("Request ID")]
        public int RequestId { get; private set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ItRepositoryAssignment")]
        public ItRepositoryProduct Product { get; private set; }
        [ForeignKey("RequestId")]
        [InverseProperty("ItRepositoryAssignment")]
        public ItRequest Request { get; private set; }
        [InverseProperty("Assignment")]
        public ICollection<ItRequestStatus> ItRequestStatus { get; private set; }
    }
}
