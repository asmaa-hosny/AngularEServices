using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Software_RequestItems")]
    public class ItSoftwareRequestItems
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("RequestID")]
        public int RequestId { get; private set; }
        [Column("AppID")]
        public int AppId { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? NeedIsDoneOn { get; private set; }
        [StringLength(15)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }

        [ForeignKey("AppId")]
        [InverseProperty("ItSoftwareRequestItems")]
        public ItSoftwareApps App { get; private set; }
        [ForeignKey("RequestId")]
        [InverseProperty("ItSoftwareRequestItems")]
        public ItSoftware Request { get; private set; }
        [ForeignKey("Status")]
        [InverseProperty("ItSoftwareRequestItems")]
        public ItStatuses StatusNavigation { get; private set; }
    }
}
