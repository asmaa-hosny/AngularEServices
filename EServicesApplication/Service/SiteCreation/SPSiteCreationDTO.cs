using EServicesApplication.Services.Common;
using EservicesDomain.Attributes;
using EservicesDomain.Common;
using EservicesDomain.Domain.SiteCreation;
using System.Collections.Generic;


namespace EServicesApplication.Services.SiteCreation
{
   
   public class SPSiteCreationDTO : BaseDTO
    {
        public SPSiteCreationDTO()
        {
            DomainModel = new SPSiteCreation();
        }
     
        public SPSiteCreation DomainModel { get; set; }

        public List<SPSiteListsAndLibraries> ListsAndLibraries { get; set; }

       public List<SPSiteMember> MembersList { get; set; }

    }

  
}
