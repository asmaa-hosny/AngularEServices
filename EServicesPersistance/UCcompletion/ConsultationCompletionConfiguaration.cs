using EservicesDomain.Common;
using EservicesDomain.Domain.UCcompletion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.UCcompletion
{
    class ConsultationCompletionConfiguaration : BaseEntityMap<ConsultationCompletionRequest, int>
    {
        public override void Configure(EntityTypeBuilder<ConsultationCompletionRequest> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateConsultation_REFID]([id]))");
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.ActualDeliverables).HasColumnType("nvarchar(max)");
            builder.Property(x => x.DurationNotes).HasColumnType("nvarchar(max)");
            builder.Property(x => x.TerminationReason).HasColumnType("nvarchar(max)");
            builder.Ignore(x => x.NodeID);
        }
    }
   
}
