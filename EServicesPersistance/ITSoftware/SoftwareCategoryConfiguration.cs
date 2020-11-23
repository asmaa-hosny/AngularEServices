using EservicesDomain.Domain.ITSoftware;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesPersistance.ITSoftware
{
    public class SoftwareCategoryConfiguration : IEntityTypeConfiguration<SoftwareCategory>
    {
        public void Configure(EntityTypeBuilder<SoftwareCategory> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.CategoryNameAR).HasMaxLength(50);
            builder.Property(x => x.CategoryNameEN).HasMaxLength(50);

            builder.ToTable("IT_Software_Category");
        }

    }
}
