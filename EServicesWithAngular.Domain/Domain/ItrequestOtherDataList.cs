using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITRequestOtherDataList")]
    public class ItrequestOtherDataList
    {
        [Column("ITRequestDataID")]
        [StringLength(50)]
        public string ItrequestDataId { get; private set; }
        [Column("ITRequestListID")]
        public int? ItrequestListId { get; private set; }
        public int? Quantity { get; private set; }
        [StringLength(15)]
        public string ItemDescription { get; private set; }
        [Column("ITRequestStatus_ID")]
        public int? ItrequestStatusId { get; private set; }
        [Column("ID")]
        public int Id { get; private set; }

        [ForeignKey("ItrequestListId")]
        [InverseProperty("ItrequestOtherDataList")]
        public ItrequestList ItrequestList { get; private set; }
        [ForeignKey("ItrequestStatusId")]
        [InverseProperty("ItrequestOtherDataList")]
        public ItrequestStatus1 ItrequestStatus { get; private set; }
    }
}
