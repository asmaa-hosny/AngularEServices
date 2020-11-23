using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.Domain.ITSoftware
{
    public class SoftwareApps : IEntity<int>
    {
        //public SoftwareApps()
        //{
        //    this.ITSoftwareRequestItems = new HashSet<SoftwareRequestItems>();
        //}
        public int CategoryID { get; set; }

        public string AppName { get; set; }

        public bool RequiresLicense { get; set; }

        //public bool IsEA { get; set; }

        public virtual SoftwareCategory ITSoftwareCategory { get; set; }

        //[Execlude]
        //public virtual ICollection<SoftwareRequestItems> ITSoftwareRequestItems { get; set; }
    }
}
