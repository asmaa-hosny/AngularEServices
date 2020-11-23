using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EservicesDomain.Domain
{
    [Table("IT_Ink")]
    public class ItInk
    {
        public ItInk()
        {
            ItInkDetails = new HashSet<ITInkDetails>();
        }

        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }

        [Required]
        [StringLength(50)]
        public string RequestType { get; private set; }

        public DateTime? Rdate { get; private set; }

        public ICollection<ITInkDetails> ItInkDetails { get; private set; }
    }
}
