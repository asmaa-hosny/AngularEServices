using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EservicesDomain.Domain
{
    [Table("IT_Software_RequestItems")]
    public class ITSoftwareRequestItems
    {

        public int Id { get; private set; }

        public int RequestId { get; private set; }

        public int AppId { get; private set; }

        public DateTime? NeedIsDoneOn { get; private set; }

        public string Status { get; private set; }

        public string UpdatedBy { get; private set; }

        public ITStatus StatusNavigation { get; private set; }
    }
}
