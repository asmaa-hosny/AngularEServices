using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EservicesDomain.Domain.ITSoftware
{
    public class Software : IKtaEntity<int>
    {
        public Software()
        {
            this.ITSoftwareRequestItems = new HashSet<SoftwareRequestItems>();
        }
        //from backEnd
        public string EmployeeEmail { get; set; }

        [Required]
        public string RequestType { get; set; }

        //public string OtherPrograms { get; set; }

        //public string Justification { get; set; }

        public int Qty { get; set; }

        public int? ContractorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RDate { get; set; }

        public  SoftwareContractor ITSoftwareContractor { get; set; }

        [Execlude]
        public virtual ICollection<SoftwareRequestItems> ITSoftwareRequestItems { get; set; }
    }
}
