using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EservicesDomain.VPN
{
    [Table("IT_VPN_VPNGroups")]
    public class ITVpnGroups : IEntity<int>
    {
        public ITVpnGroups()
        {
            ItVpnRequestedGroups = new HashSet<ITVpnRequestedGroups>();
        }

        [Required]
        [Column("VPNGroupNameEN")]
        [StringLength(50)]
        public string VpngroupNameEn { get; private set; }

        [Required]
        [Column("VPNGroupNameAR")]
        [StringLength(50)]
        public string VpngroupNameAr { get; private set; }

        [StringLength(50)]
        public string TunnelGroup { get; private set; }

        [StringLength(50)]
        public string GroupPassword { get; private set; }

        [Column("z score")]
        public int? ZScore { get; private set; }

        public bool OnlyForSysAdmins { get; private set; }

        [InverseProperty("Vpngroup")]
        public ICollection<ITVpnRequestedGroups> ItVpnRequestedGroups { get; private set; }
    }
}
