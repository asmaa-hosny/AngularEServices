using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Ink_Details")]
    public class ItInkDetails
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("RequestID")]
        public int RequestId { get; private set; }
        [Column("ColorID")]
        public int ColorId { get; private set; }
        [StringLength(15)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }

        [ForeignKey("ColorId")]
        [InverseProperty("ItInkDetails")]
        public ItInkColors Color { get; private set; }
        [ForeignKey("RequestId")]
        [InverseProperty("ItInkDetails")]
        public ItInk Request { get; private set; }
        [ForeignKey("Status")]
        [InverseProperty("ItInkDetails")]
        public ItStatuses StatusNavigation { get; private set; }
    }
}
