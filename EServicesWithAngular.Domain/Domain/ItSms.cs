using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_SMS")]
    public class ItSms
    {
        [Column("ID")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? CreationDate { get; private set; }
        [StringLength(2000)]
        public string SendTo { get; private set; }
        [StringLength(500)]
        public string Message { get; private set; }
    }
}
