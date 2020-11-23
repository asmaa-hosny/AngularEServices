using EservicesDomain.Common;
using EservicesDomain.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.Domain.SiteCreation
{
  public  class SPSiteCreation :IKtaEntity<int>
    {
        public SPSiteCreation()
        {
            this.ITSPSiteListsAndLibraries = new HashSet< SPSiteListsAndLibraries>();
            this.ITSPSiteMember = new HashSet< SPSiteMember>();
        }

        public string EmployeeEmail { get; set; }
       
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation })]
        [Required]
        public string ProposedSiteName { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation })]
        [Required]
        public string SiteJustification { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation })]
        [Required]
        public string SiteDescription { get; set; }

        public string SiteOwnerEmail { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_SPAdminNodeId })]

        public string SiteType { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_SPAdminNodeId })]

        public string SiteDisplayName { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_SPAdminNodeId })]

        public string SiteName { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_SPAdminNodeId })]

        public string SiteLink { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_SPAdminNodeId })]

        public string Notes { get; set; }
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_SPAdminNodeId })]

        public string ContentDatabase { get; set; }

        public string DepartmentOfRequestor { get; set; }

        public string SectorOfRequestor { get; set; }
        public ICollection<SPSiteListsAndLibraries> ITSPSiteListsAndLibraries { get; set; }
        public ICollection<SPSiteMember> ITSPSiteMember { get; set; }
    }
}
