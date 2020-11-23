using EservicesDomain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesPersistance.ITResignation
{
    public class ITResignationStatusConfiguaration : IEntityTypeConfiguration<ITResignationItemStatus>
    {
        public void Configure(EntityTypeBuilder<ITResignationItemStatus> builder)
        {
            builder.HasOne(x => x.IT_Resignation).
                WithMany(r => r.ITResignationItemStatus).
                HasForeignKey(x => x.RequestId);

            builder.HasOne(x => x.ITResignationItem).
                WithMany(r => r.ITResignationItemStatus).
                HasForeignKey(x => x.ItemId);

            builder.Property(x => x.ItemId).HasColumnName("Item_Id");
            builder.Property(x => x.RequestId).HasColumnName("Request_Id");
            builder.HasOne(x => x.ITStatus).
              WithMany().
              HasForeignKey(x => x.Status);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.ToTable("IT_ResignationItems_Status");
        }
    }
}
