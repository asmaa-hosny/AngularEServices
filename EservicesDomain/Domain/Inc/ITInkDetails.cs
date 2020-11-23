using EservicesDomain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EservicesDomain.Domain
{

    public class ITInkDetails
    {
        public int Id { get; private set; }

        public int RequestId { get; private set; }

        public int ColorId { get; private set; }

        public string Status { get; private set; }

        public string UpdatedBy { get; private set; }

        public ITInkColors Color { get; private set; }

        public ItInk Request { get; private set; }

        public ITStatus StatusNavigation { get; private set; }
    }
}
