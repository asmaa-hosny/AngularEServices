using EservicesDomain.Common;
using EservicesDomain.Domain.ITServerAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.ITServerAccess
{
    class ServerDetailsConfiguration : IEntityTypeConfiguration<ServerDetails>
    {
        public void Configure(EntityTypeBuilder<ServerDetails> builder)
        {
            builder.Property(x => x.ServerName).HasMaxLength(50);
            builder.Property(x => x.ServerIP).HasMaxLength(50);
            builder.Property(x => x.IsAdmin).HasMaxLength(1);
            builder.Property(x => x.AssociatedTo).HasMaxLength(50);
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.HasOne<ServerAccess>().WithMany(x => x.RequiredServersDetails).HasForeignKey(x => x.AssociatedTo);
            builder.ToTable("IT_ServerAccess_ServersList");
        }


    }
}
