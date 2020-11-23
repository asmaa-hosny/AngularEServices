using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("Core_Exceptions_Solutions")]
    public class CoreExceptionsSolutions
    {
        public CoreExceptionsSolutions()
        {
            CoreExceptions = new HashSet<CoreExceptions>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column(TypeName = "text")]
        public string Description { get; private set; }

        [InverseProperty("SolutionNavigation")]
        public ICollection<CoreExceptions> CoreExceptions { get; private set; }
    }
}
