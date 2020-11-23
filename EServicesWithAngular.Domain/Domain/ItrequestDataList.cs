using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITRequestDataList")]
    public class ItrequestDataList
    {
        [Required]
        [Column("ITRequestDataID")]
        [StringLength(50)]
        public string ItrequestDataId { get; private set; }
        [Column("ITRequestListID")]
        public int ItrequestListId { get; private set; }
        public int? Quantity { get; private set; }
        [Column("TypeID")]
        public int? TypeId { get; private set; }
        [Column("ITRequestStatus_ID")]
        public int? ItrequestStatusId { get; private set; }
        [Column("ID")]
        public int Id { get; private set; }

        [ForeignKey("Id")]
        [InverseProperty("InverseIdNavigation")]
        public ItrequestDataList IdNavigation { get; private set; }
        [ForeignKey("ItrequestDataId")]
        [InverseProperty("ItrequestDataList")]
        public ItrequestData ItrequestData { get; private set; }
        [ForeignKey("ItrequestListId")]
        [InverseProperty("ItrequestDataList")]
        public ItrequestList ItrequestList { get; private set; }
        [ForeignKey("ItrequestStatusId")]
        [InverseProperty("ItrequestDataList")]
        public ItrequestStatus1 ItrequestStatus { get; private set; }
        [ForeignKey("TypeId")]
        [InverseProperty("ItrequestDataList")]
        public ItrequestListTypes Type { get; private set; }
        [InverseProperty("IdNavigation")]
        public ItrequestDataList InverseIdNavigation { get; private set; }
    }
}
