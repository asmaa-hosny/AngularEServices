using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.Domain.SiteCreation
{
  public class SPSiteMember :IEntity<int>
    {
        public int RequestID { get; set; }

        public string MemberName { get; set; }

        public string MemberEmail { get; set; }

        public string Permission { get; set; }
        public int PermissionID { get; set; }

        public bool IsAdmin { get; set; }
       

    }
}
