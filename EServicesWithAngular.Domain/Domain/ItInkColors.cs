using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Ink_Colors")]
    public class ItInkColors
    {
        public ItInkColors()
        {
            ItInkDetails = new HashSet<ItInkDetails>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("PrinterID")]
        public int PrinterId { get; private set; }
        [Required]
        [StringLength(50)]
        public string Color { get; private set; }
        [Column("Color_AR")]
        [StringLength(50)]
        public string ColorAr { get; private set; }

        [ForeignKey("PrinterId")]
        [InverseProperty("ItInkColors")]
        public ItInkPrinters Printer { get; private set; }
        [InverseProperty("Color")]
        public ICollection<ItInkDetails> ItInkDetails { get; private set; }
    }
}
