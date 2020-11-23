using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("Core_EmailTemplates")]
    public class CoreEmailTemplates
    {
        [Key]
        [StringLength(50)]
        public string Name { get; private set; }
        [Required]
        [StringLength(256)]
        public string Subject { get; private set; }
        [Required]
        [Column("Body AR")]
        public string BodyAr { get; private set; }
        [Required]
        [Column("Body EN")]
        public string BodyEn { get; private set; }
        [Column("Action Message AR")]
        public string ActionMessageAr { get; private set; }
        [Column("Action Message EN")]
        public string ActionMessageEn { get; private set; }
    }
}
