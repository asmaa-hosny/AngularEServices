using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EServicesApplication.Services.SiteCreation
{
   public class SPSiteAdminModel
    {
        [Required]
        public string SiteType { get; set; }

        [Required]
        public string SiteDisplayName { get; set; }

        [Required]
        public string SiteActualName { get; set; }
        
        [RegularExpression(pattern: @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$")]
        [Required]
        public string SiteLink { get; set; }

        [Required]
        public string ContentDatabase { get; set; }

        public string DepartmentOfRequestor { get; set; }
        
       public string SectorOfRequestor { get; set; }

        public string Notes { get; set; }
    }

}
