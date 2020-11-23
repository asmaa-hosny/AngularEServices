using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_EmailGroup_Members")]
    public class ItEmailGroupMembers
    {
        public int AssociatedTo { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string MemberEmail { get; private set; }
    }
}
