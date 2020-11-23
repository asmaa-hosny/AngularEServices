using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("IT_SPSiteCreation")]
    public class ItSpsiteCreation
    {
        public ItSpsiteCreation()
        {
            ItSpsiteCreationListsAndLibraries = new HashSet<ItSpsiteCreationListsAndLibraries>();
            ItSpsiteCreationSiteMembers = new HashSet<ItSpsiteCreationSiteMembers>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(13)]
        public string RefId { get; private set; }
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [StringLength(50)]
        public string ProposedSiteName { get; private set; }
        [StringLength(1000)]
        public string SiteJustification { get; private set; }
        [StringLength(1000)]
        public string SiteDescription { get; private set; }
        [StringLength(50)]
        public string SiteOwnerEmail { get; private set; }
        [StringLength(50)]
        public string SiteType { get; private set; }
        [StringLength(50)]
        public string SiteDisplayName { get; private set; }
        [StringLength(50)]
        public string SiteName { get; private set; }
        [StringLength(100)]
        public string SiteLink { get; private set; }
        [StringLength(50)]
        public string ContentDatabase { get; private set; }
        [StringLength(500)]
        public string DepartmentOfRequestor { get; private set; }
        [StringLength(500)]
        public string SectorOfRequestor { get; private set; }
        [StringLength(1000)]
        public string Notes { get; private set; }

        [InverseProperty("Request")]
        public ICollection<ItSpsiteCreationListsAndLibraries> ItSpsiteCreationListsAndLibraries { get; private set; }
        [InverseProperty("Request")]
        public ICollection<ItSpsiteCreationSiteMembers> ItSpsiteCreationSiteMembers { get; private set; }
    }
}
