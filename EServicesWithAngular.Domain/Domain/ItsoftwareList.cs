using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITSoftwareList")]
    public class ItsoftwareList
    {
        [Column("ID")]
        public int Id { get; private set; }
        [Column("IsEA")]
        public bool? IsEa { get; private set; }
        [Column("ITRequestList_ID")]
        public int? ItrequestListId { get; private set; }
    }
}
