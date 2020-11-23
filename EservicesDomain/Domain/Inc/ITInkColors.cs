using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EservicesDomain.Domain
{

    public class ITInkColors : IEntity<int>
    {
        public ITInkColors()
        {
            ItInkDetails = new HashSet<ITInkDetails>();
        }

        public int PrinterId { get; private set; }

        [Required]
        public string Color { get; private set; }

        public string ColorAr { get; private set; }

        public ITInkPrinter Printer { get; private set; }

        public ICollection<ITInkDetails> ItInkDetails { get; private set; }
    }
}
