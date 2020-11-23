using Microsoft.EntityFrameworkCore;
using EservicesDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.ITResignation
{
    public class ITStatusConfiguaration : IEntityTypeConfiguration<ITStatus>
    {
        public void Configure(EntityTypeBuilder<ITStatus> builder)
        {
            builder.HasKey(x => x.Id).HasName("Code");
            builder.Property(x => x.Id).HasMaxLength(15);
            builder.Property(x => x.StatusTextAr).HasMaxLength(50);
            builder.Property(x => x.StatusTextEn).HasMaxLength(50);
            builder.ToTable("IT_Statuses");
        }
    }
}
