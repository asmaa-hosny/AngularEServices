using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("Core_Status")]
    public class CoreStatus
    {
        public CoreStatus()
        {
            ItrequestData = new HashSet<ItrequestData>();
        }

        [Column("ID")]
        public int Id { get; private set; }
        [Column("AR_Status")]
        [StringLength(50)]
        public string ArStatus { get; private set; }
        [Column("EN_Status")]
        [StringLength(50)]
        public string EnStatus { get; private set; }

        [InverseProperty("StatusNavigation")]
        public ICollection<ItrequestData> ItrequestData { get; private set; }
    }
}
