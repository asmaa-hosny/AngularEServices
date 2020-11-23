using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_Request_Contractor")]
    public class ItRequestContractor
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("IT Request ID")]
        public int? ItRequestId { get; private set; }
        [Column("Contractor Name")]
        [StringLength(50)]
        public string ContractorName { get; private set; }
        [Column("Contractor Project")]
        [StringLength(50)]
        public string ContractorProject { get; private set; }
        [Column("Contractor Email")]
        [StringLength(50)]
        public string ContractorEmail { get; private set; }
        [Column("Contractor Company")]
        [StringLength(50)]
        public string ContractorCompany { get; private set; }
        [Column("Contarctor Mobile")]
        [StringLength(50)]
        public string ContarctorMobile { get; private set; }

        [ForeignKey("ItRequestId")]
        [InverseProperty("ItRequestContractor")]
        public ItRequest ItRequest { get; private set; }
    }
}
