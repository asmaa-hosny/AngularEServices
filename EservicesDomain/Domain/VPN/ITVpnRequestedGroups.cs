using EservicesDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EservicesDomain.VPN
{
    [Table("IT_VPN_RequestedGroups")]
    public class ITVpnRequestedGroups : IEntity<int>
    {
        public int AssociatedTo { get; private set; }

        [Column("VPNGroupID")]
        public int VpngroupId { get; private set; }

        [Required]
        [StringLength(200)]
        public string Justification { get; private set; }

        [ForeignKey("AssociatedTo")]
        [InverseProperty("ItVpnRequestedGroups")]
        public ITVpn AssociatedToNavigation { get; private set; }

        [ForeignKey("VpngroupId")]
        [InverseProperty("ItVpnRequestedGroups")]
        public ITVpnGroups Vpngroup { get; private set; }
    }
}
