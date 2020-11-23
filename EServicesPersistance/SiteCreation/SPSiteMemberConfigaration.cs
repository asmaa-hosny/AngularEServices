using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EservicesDomain.Domain;
using EservicesDomain.Domain.SiteCreation;

namespace EServicesPersistance.SiteCreation
{
   class SPSiteMemberConfigaration : IEntityTypeConfiguration<SPSiteMember>
    {
        public void Configure(EntityTypeBuilder<SPSiteMember> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.HasOne<SPSiteCreation>().WithMany(x => x.ITSPSiteMember).HasForeignKey(x => x.RequestID);
            //builder.Property(x => x.Permission).IsRequired();
          //  builder.Property(x => x.MemberEmail).IsRequired();
            builder.ToTable("IT_SPSiteCreation_SiteMembers"); 
        }
    }
}
