using EservicesDomain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesPersistance.ITSoftware
{
    public class ITStatusConfiguration: IEntityTypeConfiguration<ITStatus>
    {
        public void Configure(EntityTypeBuilder<ITStatus> builder)
        {
            builder.HasKey(x => x.Id).HasName("Code");
            builder.Property(x => x.Id).HasMaxLength(15).HasColumnName("Code");
            builder.Property(x => x.StatusTextAr).HasMaxLength(50);
            builder.Property(x => x.StatusTextEn).HasMaxLength(50);
            builder.ToTable("IT_Statuses");
        }
    }
}
