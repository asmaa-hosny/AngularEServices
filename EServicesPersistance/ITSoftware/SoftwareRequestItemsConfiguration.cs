using EservicesDomain.Domain;
using EservicesDomain.Domain.ITSoftware;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.ITSoftware
{
    public class SoftwareRequestItemsConfiguration : IEntityTypeConfiguration<SoftwareRequestItems>
    {

        public void Configure(EntityTypeBuilder<SoftwareRequestItems> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.NeedIsDoneOn);
            builder.Property(x => x.UpdatedBy).HasMaxLength(50);
            builder.Property(x => x.AppName).HasMaxLength(500);
            builder.Property(x => x.Justification).HasMaxLength(500);
            builder.Property(x => x.Link).HasMaxLength(500);
            builder.HasOne(x => x.ITSoftware).WithMany(x => x.ITSoftwareRequestItems).HasForeignKey(x => x.RequestID);
            builder.HasOne(x => x.ITSoftwareApps).WithMany().HasForeignKey(x => x.AppID);
            builder.HasOne(x => x.ITStatuses).WithMany(). HasForeignKey(x => x.Status);

            builder.ToTable("IT_Software_RequestItems");
        }
    }
}
