using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    public class CarsTypes
    {
        public CarsTypes()
        {
            Cars = new HashSet<Cars>();
        }

        [Column("CarsTypes")]
        [StringLength(50)]
        public string CarsTypes1 { get; private set; }
        [Column("ID")]
        public int Id { get; private set; }
        [Column("CarsTypes_AR")]
        [StringLength(50)]
        public string CarsTypesAr { get; private set; }

        [InverseProperty("Type")]
        public ICollection<Cars> Cars { get; private set; }
    }
}
