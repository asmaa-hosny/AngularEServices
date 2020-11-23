using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Ink_Printers")]
    public class ItInkPrinters
    {
        public ItInkPrinters()
        {
            ItInkColors = new HashSet<ItInkColors>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [StringLength(50)]
        public string PrinterName { get; private set; }

        [InverseProperty("Printer")]
        public ICollection<ItInkColors> ItInkColors { get; private set; }
    }
}
