using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("CarRequest_Times")]
    public class CarRequestTimes
    {
        [Column("ID")]
        public int Id { get; private set; }
        [StringLength(10)]
        public string Time { get; private set; }
    }
}
