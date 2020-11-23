
using EservicesDomain.Domain.UCcompletion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.UCcompletion
{
   public class ConsultantEvaluationConfiguaration : IEntityTypeConfiguration<ConsultantEvaluation>
    {
        public void Configure(EntityTypeBuilder<ConsultantEvaluation> builder)
        {
            builder.Property(x => x.Comments).HasColumnType("nvarchar(max)");

            builder.ToTable("ConsultantEvaluation");
        }
    }
}
