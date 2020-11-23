using System;

using System.Threading.Tasks;
using EServicesApplication.Interfaces.Persistence;
using EservicesDomain.Domain;
using EservicesDomain.Domain.ITGroupEmail;
using EservicesDomain.Domain.AdTranslation;
using EservicesDomain.Domain.SiteCreation;
using EservicesDomain.Domain.UCcompletion;
using EservicesDomain.Domain.Workflow;
using EservicesDomain.VPN;
using Microsoft.EntityFrameworkCore;
using EservicesDomain.Domain.UC;
using EservicesDomain.Domain.ITServerAccess;
using EservicesDomain.Domain.ITSoftware;

namespace EServicesPersistance.Common
{
    public class DBContext : DbContext, IServiceDBContext,IDisposable
    {
        public DbSet<ITVpn> ITVpn { get; set; }

       public DbSet<CoreApproval> CoreApproval { get; set; }

        public DbSet<DecisionChoices> DecisionChoices { get; set; }

        public DbSet<ITAccount> ITAccount { get; set; }
        public DbSet<ConsultationRequest> ConsultationRequest { get; set; }
        public DbSet <ConsultantAvailability> ConsultantAvailability { get; set; }
        public DbSet<ConsultationCompletionRequest> ConsultationCompletionRequest { get; set; }
        public DbSet<ConsultantEvaluation> ConsultantEvaluation { get; set; }
        public DbSet<ConsultantEvaluationItems> ConsultantEvaluationItems { get; set; }
        public DbSet<ConsultationQuestions> ConsultationQuestions { get; set; }
        
        public DbSet <SPSiteCreation> SPSiteCreation { get; set; }
        public DbSet<SPSiteListsAndLibraries> SPSiteListsAndLibraries { get; set; }
        public DbSet<SPSiteMember> SPSiteMember { get; set; }

        public DbSet<EservicesDomain.Domain.ITResignation> ITResignation { get; set; }

        public DbSet<ITResignationItem> ITResignationItem { get; set; }

        public DbSet<ITResignationItemStatus> ITResignationItemStatus { get; set; }
        public DbSet<EmailGroup> EmailGroup { get; set; }
        public DbSet<EmailGroupMember> EmailGroupMember { get; set; }
        public DbSet<EservicesDomain.Domain.AdTranslation.AdminTranslation> AdminTranslation { get; set; }
        public DbSet<AdminTranslator> AdminTranslator { get; set; }
        public DbSet<TranslationInstructions> TranslationInstructions { get; set; }

        public DbSet<Software> Software { get; set; }
        public DbSet<SoftwareApps> SoftwareApps { get; set; }
        public DbSet<SoftwareCategory> SoftwareCategory { get; set; }
        public DbSet<SoftwareContractor> SoftwareContractor { get; set; }
        public DbSet<SoftwareRequestItems> SoftwareRequestItems { get; set; }


        public DbSet<ITVpnGroups> ITVpnGroups { get; set; }

        public DbSet<ITVpnRequestedGroups> ITVpnRequestedGroups { get; set; }
        //public DbSet<CoreApproval> CoreApproval { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ServerAccess> ServerAccess { get; set; }

        public DbSet<ServerDetails> ServerDetails { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public void Save()
        {
            base.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync().ConfigureAwait(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
        }
               
        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override void Dispose()
        {
            base.Dispose();
        }



    }
}
