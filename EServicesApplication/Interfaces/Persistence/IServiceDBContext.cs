using EservicesDomain.VPN;
using EservicesDomain.Common;
using Microsoft;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EservicesDomain.Domain.Workflow;
using EservicesDomain.Domain.SiteCreation;

using EservicesDomain.Domain;
using EservicesDomain.Domain.ITServerAccess;

using EservicesDomain.Domain.ITSoftware;

namespace EServicesApplication.Interfaces.Persistence
{
    public interface IServiceDBContext : IDatabaseContext
    {
        public DbSet<ITVpn> ITVpn { get; set; }

        public DbSet<CoreApproval> CoreApproval { get; set; }

        public DbSet<DecisionChoices> DecisionChoices { get; set; }

        public DbSet<ITAccount> ITAccount { get; set; }
        public DbSet<SPSiteCreation> SPSiteCreation { get; set; }

        public DbSet<SPSiteListsAndLibraries> SPSiteListsAndLibraries { get; set; }

        public DbSet<SPSiteMember> SPSiteMember { get; set; }

        public DbSet<ITVpnGroups> ITVpnGroups { get; set; }

        public DbSet<ITVpnRequestedGroups> ITVpnRequestedGroups { get; set; }

        public DbSet<EservicesDomain.Domain.ITResignation> ITResignation { get; set; }

        public DbSet<ITResignationItem> ITResignationItem { get; set; }

        public DbSet<ITResignationItemStatus> ITResignationItemStatus { get; set; }
        public DbSet<ServerAccess> ServerAccess { get; set; }

        public DbSet<ServerDetails> ServerDetails { get; set; }

        public DbSet<Software> Software { get; set; }
        public DbSet<SoftwareApps> SoftwareApps { get; set; }
        public DbSet<SoftwareCategory> SoftwareCategory { get; set; }
        public DbSet<SoftwareContractor> SoftwareContractor { get; set; }
        public DbSet<SoftwareRequestItems> SoftwareRequestItems { get; set; }
    }
}
