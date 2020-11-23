using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EservicesDomain.VPN
{
    [Table("IT_VPN")]
    public class ITVpn : IKtaEntity<int>
    {
        public ITVpn()
        {
            ItVpnRequestedGroups = new HashSet<ITVpnRequestedGroups>();
        }

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
        public ICollection<ITVpnRequestedGroups> ItVpnRequestedGroups { get; private set; }
    }
}
