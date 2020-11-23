using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITRequestList")]
    public class ItrequestList
    {
        public ItrequestList()
        {
            ItrequestDataList = new HashSet<ItrequestDataList>();
            ItrequestListTypes = new HashSet<ItrequestListTypes>();
            ItrequestOtherDataList = new HashSet<ItrequestOtherDataList>();
        }

        [Column("ID")]
        public int Id { get; private set; }
        [Column("AR")]
        [StringLength(100)]
        public string Ar { get; private set; }
        [Column("EN")]
        [StringLength(100)]
        public string En { get; private set; }
        [StringLength(50)]
        public string Path { get; private set; }

        [InverseProperty("ItrequestList")]
        public ICollection<ItrequestDataList> ItrequestDataList { get; private set; }
        [InverseProperty("RequestList")]
        public ICollection<ItrequestListTypes> ItrequestListTypes { get; private set; }
        [InverseProperty("ItrequestList")]
        public ICollection<ItrequestOtherDataList> ItrequestOtherDataList { get; private set; }
    }
}
