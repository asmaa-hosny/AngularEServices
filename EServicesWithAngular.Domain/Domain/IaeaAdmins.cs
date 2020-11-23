using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IAEA_Admins")]
    public class IaeaAdmins
    {
        [Key]
        [StringLength(100)]
        public string EmployeeEmail { get; private set; }
        [StringLength(100)]
        public string EmployeeName { get; private set; }
    }
}
