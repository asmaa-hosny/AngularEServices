using EservicesDomain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.AdminTranslation
{
   public class AdminTranslationConfiguaration : BaseEntityMap<EservicesDomain.Domain.AdTranslation.AdminTranslation, int>
    {
        public override void Configure(EntityTypeBuilder<EservicesDomain.Domain.AdTranslation.AdminTranslation> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateAdmin_Translation_REFID]([id]))");
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.ManagerNotes).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Notes).HasColumnType("nvarchar(max)");
            builder.Ignore(x => x.NodeID);
            builder.ToTable("Admin_Translation");
        }
    }
}
