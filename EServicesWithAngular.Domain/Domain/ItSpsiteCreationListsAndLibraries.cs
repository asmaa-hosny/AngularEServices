using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_SPSiteCreation_ListsAndLibraries")]
    public class ItSpsiteCreationListsAndLibraries
    {
        [Column("id")]
        public int Id { get; private set; }
        [Column("RequestID")]
        public int RequestId { get; private set; }
        [Required]
        [StringLength(50)]
        public string Type { get; private set; }
        [StringLength(50)]
        public string Name { get; private set; }

        [ForeignKey("RequestId")]
        [InverseProperty("ItSpsiteCreationListsAndLibraries")]
        public ItSpsiteCreation Request { get; private set; }
    }
}
