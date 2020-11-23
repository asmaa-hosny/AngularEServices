using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EservicesDomain.Domain
{
    [Table("IT_Ink_Printers")]
    public class ITInkPrinter
    {
        public ITInkPrinter()
        {
            ItInkColors = new HashSet<ITInkColors>();
        }

        [Column("id")]
        public int Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string PrinterName { get; private set; }

        [InverseProperty("Printer")]
        public ICollection<ITInkColors> ItInkColors { get; private set; }
    }
}
