using EservicesDomain.Common;
using EservicesDomain.Domain.ITSoftware;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesPersistance.ITSoftware
{
    public class SoftwareAppsConfiguration : IEntityTypeConfiguration<SoftwareApps>
    {
        public void Configure(EntityTypeBuilder<SoftwareApps> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            //builder.Property(x => x.IsEA).HasColumnType("bit");
            builder.Property(x => x.RequiresLicense).HasColumnType("bit");
            builder.Property(x => x.AppName).HasMaxLength(100);
            builder.HasOne(x => x.ITSoftwareCategory).WithMany().HasForeignKey(x => x.CategoryID);

            builder.ToTable("IT_Software_Apps");
        }
    }

}
