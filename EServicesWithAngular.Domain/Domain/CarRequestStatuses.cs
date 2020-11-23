using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("CarRequest_Statuses")]
    public class CarRequestStatuses
    {
        public CarRequestStatuses()
        {
            CarRequest = new HashSet<CarRequest>();
        }

        [Column("ID")]
        public int Id { get; private set; }
        [Column("Status_AR")]
        [StringLength(100)]
        public string StatusAr { get; private set; }
        [Column("Status_EN")]
        [StringLength(100)]
        public string StatusEn { get; private set; }

        [InverseProperty("Status")]
        public ICollection<CarRequest> CarRequest { get; private set; }
    }
}
