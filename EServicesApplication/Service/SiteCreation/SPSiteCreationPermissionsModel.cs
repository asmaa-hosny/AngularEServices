using EservicesDomain.Attributes;
using EservicesDomain.Domain.SiteCreation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesApplication.Services.SiteCreation
{
   public class SPSiteCreationPermissionsModel
    {
       
        public string Admin { get; set; }
         public List<SPSiteMember> Members { get; set; }
       
    }
}
