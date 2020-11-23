using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_ServerAccess_ServersList")]
    public class ItServerAccessServersList
    {
        public int AssociatedTo { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string ServerName { get; private set; }
        [Column("ServerIP")]
        [StringLength(50)]
        public string ServerIp { get; private set; }
        public bool? IsAdmin { get; private set; }
    }
}
