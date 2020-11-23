using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using EservicesDomain.Domain.ITSoftware;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EServicesPersistance.ITSoftware
{
    public class SoftwareConfiguration : BaseEntityMap<Software, int>
    {
        public override void Configure(EntityTypeBuilder<Software> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.EmployeeEmail).HasMaxLength(50);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateIT_Software_REFID]([id]))");
            builder.Property(x => x.RequestType).HasMaxLength(50);
            builder.Property(x => x.Qty).HasDefaultValue(1);
            builder.Property(x => x.RDate);
            builder.HasOne(x => x.ITSoftwareContractor).WithMany().HasForeignKey(x => x.ContractorId);

            builder.Ignore(x => x.NodeID);
            builder.ToTable("IT_Software");
        }
    }
}
