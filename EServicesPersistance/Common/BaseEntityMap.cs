using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EservicesDomain.Common
{
    public class BaseEntityMap<T, Tid> : IEntityTypeConfiguration<T> where T : IKtaEntity<Tid>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.JobId).HasColumnName("JobID").HasMaxLength(50);

            builder.Property(e => e.RefId).HasColumnName("REF_ID").HasMaxLength(50);
        }
    }
}
