using EservicesDomain.Domain.ITCareService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.ITCareService
{
    public class ITCareConfiguaration : IEntityTypeConfiguration<ITCareRequest>
    {
        public  void Configure(EntityTypeBuilder<ITCareRequest> builder)
        {
            builder.Property(x => x.Id).HasColumnName("RequestId");
            builder.Property(x => x.JobId).HasMaxLength(50);
            builder.ToTable("IT_CareRequest");
        }

    }



}
