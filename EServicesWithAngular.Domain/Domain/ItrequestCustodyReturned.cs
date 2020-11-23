using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITRequest_CustodyReturned")]
    public class ItrequestCustodyReturned
    {
        [Column("ID")]
        public int Id { get; private set; }
        [StringLength(200)]
        public string Notes { get; private set; }
        [StringLength(200)]
        public string AddedBy { get; private set; }
    }
}
