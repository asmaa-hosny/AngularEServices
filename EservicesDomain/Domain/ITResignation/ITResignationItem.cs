using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.Domain
{
    public class ITResignationItem : IEntity<int>
    {
        public ITResignationItem()
        {
            this.ITResignationItemStatus = new List<ITResignationItemStatus>();
        }

        public string ItemAR { get; set; }

        public string ItemEN { get; set; }

        public int? NodeId { get; set; }

        public ICollection<ITResignationItemStatus> ITResignationItemStatus { get; set; }

    }
}
