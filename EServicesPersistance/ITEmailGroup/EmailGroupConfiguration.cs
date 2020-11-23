using EservicesDomain.Common;
using EservicesDomain.Domain.ITGroupEmail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesPersistance.ITEmailGroup
{
    class EmailGroupConfiguration : BaseEntityMap<EmailGroup, int>
    {
        public override void Configure(EntityTypeBuilder<EmailGroup> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateIT_SPSiteCreation_REFID]([id]))");
            builder.Property(e => e.Justification).IsRequired();
            builder.Property(e => e.EmployeeEmail).IsRequired();
            builder.Property(e => e.EmailName).IsRequired();
            builder.Ignore(x => x.NodeID);
            builder.ToTable("IT_EmailGroup");
        }
    }
}
