using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    public class CarRequestPurpose
    {
        public CarRequestPurpose()
        {
            CarRequest = new HashSet<CarRequest>();
        }

        [Key]
        [Column("RequestPurposeID")]
        public int RequestPurposeId { get; private set; }
        [Column("RequestPurposeEN")]
        [StringLength(100)]
        public string RequestPurposeEn { get; private set; }
        [Column("RequestPurposeAR")]
        [StringLength(100)]
        public string RequestPurposeAr { get; private set; }

        [InverseProperty("RequestPurpose")]
        public ICollection<CarRequest> CarRequest { get; private set; }
    }
}
