using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.Domain.ITSoftware
{
    public class SoftwareCategory :  IEntity<int>
    {
        //public SoftwareCategory()
        //{
        //    this.ITSoftwareApps = new HashSet<SoftwareApps>();
        //}
        public string CategoryNameAR { get; set; }

        public string CategoryNameEN { get; set; }

        //[Execlude]
        //public virtual ICollection<SoftwareApps> ITSoftwareApps { get; set; }
    }
}
