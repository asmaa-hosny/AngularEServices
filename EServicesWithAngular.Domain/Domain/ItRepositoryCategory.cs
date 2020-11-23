using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Repository_Category")]
    public class ItRepositoryCategory
    {
        public ItRepositoryCategory()
        {
            ItRepositoryProduct = new HashSet<ItRepositoryProduct>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("Category Name")]
        [StringLength(50)]
        public string CategoryName { get; private set; }
        [Column("Parent Category")]
        public int? ParentCategory { get; private set; }

        [ForeignKey("Id")]
        [InverseProperty("InverseIdNavigation")]
        public ItRepositoryCategory IdNavigation { get; private set; }
        [InverseProperty("IdNavigation")]
        public ItRepositoryCategory InverseIdNavigation { get; private set; }
        [InverseProperty("CategoryNavigation")]
        public ICollection<ItRepositoryProduct> ItRepositoryProduct { get; private set; }
    }
}
