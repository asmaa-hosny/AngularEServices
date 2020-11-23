using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_OnBehalfOf")]
    public class HrOnBehalfOf
    {
        [Column("ID")]
        public int Id { get; private set; }
        [Required]
        [StringLength(50)]
        public string FromUsername { get; private set; }
        [Required]
        [StringLength(50)]
        public string ToUsername { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime FromDate { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime ToDate { get; private set; }
    }
}
