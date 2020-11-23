using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("Core_EmailRequestDetails")]
    public class CoreEmailRequestDetails
    {
        [Key]
        [StringLength(50)]
        public string Name { get; private set; }
        [Required]
        [Column("Details AR")]
        public string DetailsAr { get; private set; }
        [Required]
        [Column("Details EN")]
        public string DetailsEn { get; private set; }
    }
}
