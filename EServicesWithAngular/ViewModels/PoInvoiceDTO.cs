using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Models
{
    public class POInvoiceDTO : BaseViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }

        public string Vendor { get; set; }

        public decimal Amount { get; set; }
    }
}
