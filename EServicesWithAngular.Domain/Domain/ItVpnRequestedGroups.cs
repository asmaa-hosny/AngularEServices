using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_VPN_RequestedGroups")]
    public class ItVpnRequestedGroups
    {
        public int AssociatedTo { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [Column("VPNGroupID")]
        public int VpngroupId { get; private set; }
        [Required]
        [StringLength(200)]
        public string Justification { get; private set; }

        [ForeignKey("AssociatedTo")]
        [InverseProperty("ItVpnRequestedGroups")]
        public ItVpn AssociatedToNavigation { get; private set; }
        [ForeignKey("VpngroupId")]
        [InverseProperty("ItVpnRequestedGroups")]
        public ItVpnVpngroups Vpngroup { get; private set; }
    }
}
