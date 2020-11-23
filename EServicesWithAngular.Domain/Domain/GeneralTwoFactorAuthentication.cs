using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("General_TwoFactorAuthentication")]
    public class GeneralTwoFactorAuthentication
    {
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("APP")]
        [StringLength(50)]
        public string App { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime CodeExpiry { get; private set; }
        [Required]
        [StringLength(10)]
        public string Code { get; private set; }
        [Required]
        [StringLength(50)]
        public string Mobile { get; private set; }
        public int Trials { get; private set; }
    }
}
