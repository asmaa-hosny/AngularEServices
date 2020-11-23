using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EservicesDomain.Domain.ITSoftware
{
    public class SoftwareContractor : IEntity<int>
    {
        [Required]
        public string ContractorName { get; set; }

        [Required]
        public string ContractorProject { get; set; }

        [Required]
        public string ContractorEmail { get; set; }

        [Required]
        public string ContractorCompany { get; set; }

        [Required]
        public string ContractorPhone { get; set; }

    }
}
