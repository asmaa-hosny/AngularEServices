using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITRequestListTypes")]
    public class ItrequestListTypes
    {
        public ItrequestListTypes()
        {
            ItrequestDataList = new HashSet<ItrequestDataList>();
        }

        [Column("ID")]
        public int Id { get; private set; }
        [Column("RequestListID")]
        public int? RequestListId { get; private set; }
        [Column("AR_Type")]
        [StringLength(500)]
        public string ArType { get; private set; }
        [Column("EN_Type")]
        [StringLength(500)]
        public string EnType { get; private set; }
        [Column("Default_State_ID")]
        public int? DefaultStateId { get; private set; }

        [ForeignKey("RequestListId")]
        [InverseProperty("ItrequestListTypes")]
        public ItrequestList RequestList { get; private set; }
        [InverseProperty("Type")]
        public ICollection<ItrequestDataList> ItrequestDataList { get; private set; }
    }
}
