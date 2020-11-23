using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_BusinessCard_Quantity")]
    public class PrBusinessCardQuantity
    {
        public PrBusinessCardQuantity()
        {
            PrBusinessCardRequest = new HashSet<PrBusinessCardRequest>();
        }

        [Column("id")]
        public int Id { get; private set; }
        public int? Quantity { get; private set; }

        [InverseProperty("QuantityNavigation")]
        public ICollection<PrBusinessCardRequest> PrBusinessCardRequest { get; private set; }
    }
}
