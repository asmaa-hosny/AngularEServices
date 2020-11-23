using EservicesDomain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using EservicesDomain.Domain.SiteCreation;


namespace EServicesPersistance.SiteCreation
{
    class SPSiteListsAndLibrariesConfiguaration : IEntityTypeConfiguration<SPSiteListsAndLibraries>
    {
        public void Configure(EntityTypeBuilder<SPSiteListsAndLibraries> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.HasOne<SPSiteCreation>().WithMany(x => x.ITSPSiteListsAndLibraries).HasForeignKey(x => x.RequestID);
           // builder.Property(x => x.RequestID).IsRequired();
           // builder.Property(x => x.Type).IsRequired();
            builder.ToTable("IT_SPSiteCreation_ListsAndLibraries");
        }
    }
}
