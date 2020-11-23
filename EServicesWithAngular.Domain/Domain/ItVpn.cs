using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_VPN")]
    public class ItVpn
    {
        public ItVpn()
        {
            ItVpnRequestedGroups = new HashSet<ItVpnRequestedGroups>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(13)]
        public string RefId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? DateTo { get; private set; }
        [StringLength(200)]
        public string Notes { get; private set; }

        [InverseProperty("AssociatedToNavigation")]
        public ICollection<ItVpnRequestedGroups> ItVpnRequestedGroups { get; private set; }
    }
}
