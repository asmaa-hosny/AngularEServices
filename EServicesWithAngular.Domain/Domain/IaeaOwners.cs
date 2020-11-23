using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IAEA_Owners")]
    public class IaeaOwners
    {
        [Key]
        public int OwnerId { get; private set; }
        [StringLength(100)]
        public string OwnerEmail { get; private set; }
        [StringLength(100)]
        public string OwnerName { get; private set; }
    }
}
