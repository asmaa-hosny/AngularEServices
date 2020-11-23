using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Repository_Product")]
    public class ItRepositoryProduct
    {
        public ItRepositoryProduct()
        {
            ItRepositoryAssignment = new HashSet<ItRepositoryAssignment>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("Product Description")]
        [StringLength(500)]
        public string ProductDescription { get; private set; }
        public int? Category { get; private set; }
        [Column("Serial Number")]
        [StringLength(50)]
        public string SerialNumber { get; private set; }
        [Column("Production Date", TypeName = "date")]
        public DateTime? ProductionDate { get; private set; }
        [Column("Product Name")]
        [StringLength(50)]
        public string ProductName { get; private set; }

        [ForeignKey("Category")]
        [InverseProperty("ItRepositoryProduct")]
        public ItRepositoryCategory CategoryNavigation { get; private set; }
        [InverseProperty("Product")]
        public ICollection<ItRepositoryAssignment> ItRepositoryAssignment { get; private set; }
    }
}
