using EservicesDomain.Common;
using EservicesDomain.Domain.UC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.UCconsultation
{
   public class ConsultationConfiguaration : BaseEntityMap<ConsultationRequest, int>
    {
        public override void Configure(EntityTypeBuilder<ConsultationRequest> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateConsultation_REFID]([id]))");
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.ExpectedDeliverables).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Objectives).HasColumnType("nvarchar(max)");
            builder.Property(x => x.DurationNote).HasColumnType("nvarchar(max)");
            builder.Property(x => x.ConsultantDetails).HasColumnType("nvarchar(max)");
            builder.Ignore(x => x.NodeID);
      
        }
    }
}
