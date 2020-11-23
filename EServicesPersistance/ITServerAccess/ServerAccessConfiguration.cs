using EservicesDomain.Common;
using EservicesDomain.Domain.ITServerAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.ITServerAccess
{
    class ServerAccessConfiguration : BaseEntityMap<ServerAccess, int>
    {
        public override void Configure(EntityTypeBuilder<ServerAccess> builder)
        {

            base.Configure(builder);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateIT_ServerAccess_REFID]([id]))");
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.EmployeeEmail).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(1000);
            builder.Property(x => x.Justification).HasMaxLength(1000);
            builder.Property(x => x.DateFrom).HasColumnType("Date");
            builder.Property(x => x.DateTo).HasColumnType("Date");
            builder.Ignore(x => x.NodeID);

            builder.ToTable("IT_ServerAccess");
        }

    }
}
