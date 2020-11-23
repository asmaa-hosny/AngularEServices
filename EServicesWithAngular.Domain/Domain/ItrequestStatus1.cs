using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITRequestStatus")]
    public class ItrequestStatus1
    {
        public ItrequestStatus1()
        {
            ItrequestDataList = new HashSet<ItrequestDataList>();
            ItrequestOtherDataList = new HashSet<ItrequestOtherDataList>();
        }

        [Column("ID")]
        public int Id { get; private set; }
        [Column("AR_ITStatus")]
        [StringLength(100)]
        public string ArItstatus { get; private set; }
        [Column("EN_ITStatus")]
        [StringLength(100)]
        public string EnItstatus { get; private set; }

        [InverseProperty("ItrequestStatus")]
        public ICollection<ItrequestDataList> ItrequestDataList { get; private set; }
        [InverseProperty("ItrequestStatus")]
        public ICollection<ItrequestOtherDataList> ItrequestOtherDataList { get; private set; }
    }
}
