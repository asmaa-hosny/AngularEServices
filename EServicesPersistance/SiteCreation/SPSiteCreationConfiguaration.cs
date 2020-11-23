using EservicesDomain.Common;
using EservicesDomain.Domain.SiteCreation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.SiteCreation
{
    class SPSiteCreationConfiguaration : BaseEntityMap<SPSiteCreation, int>
    {
        public override void Configure(EntityTypeBuilder<SPSiteCreation> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateIT_SPSiteCreation_REFID]([id]))");
           // builder.Property(x => x.SiteName).IsRequired();
          //  builder.Property(x => x.SiteDescription).IsRequired();
            builder.Ignore(x => x.NodeID);
            builder.ToTable("IT_SPSiteCreation");
        }
    }
}
