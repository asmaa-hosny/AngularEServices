using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    public class Cars
    {
        public Cars()
        {
            CarRequest = new HashSet<CarRequest>();
        }

        [Column("ID")]
        public int Id { get; private set; }
        [Column("TypeID")]
        public int? TypeId { get; private set; }
        [StringLength(50)]
        public string PlateNo { get; private set; }
        [StringLength(50)]
        public string Color { get; private set; }
        [StringLength(10)]
        public string ModelYear { get; private set; }
        public bool? Available { get; private set; }
        public int? OdometerReading { get; private set; }
        [StringLength(50)]
        public string ModelName { get; private set; }

        [ForeignKey("TypeId")]
        [InverseProperty("Cars")]
        public CarsTypes Type { get; private set; }
        [InverseProperty("Car")]
        public ICollection<CarRequest> CarRequest { get; private set; }
    }
}
