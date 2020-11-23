using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_SPSiteCreation_SiteMembers")]
    public class ItSpsiteCreationSiteMembers
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("RequestID")]
        public int RequestId { get; private set; }
        [Required]
        [StringLength(50)]
        public string MemberEmail { get; private set; }
        [StringLength(50)]
        public string Permission { get; private set; }
        [StringLength(50)]
        public string MemberName { get; private set; }

        [ForeignKey("RequestId")]
        [InverseProperty("ItSpsiteCreationSiteMembers")]
        public ItSpsiteCreation Request { get; private set; }
    }
}
