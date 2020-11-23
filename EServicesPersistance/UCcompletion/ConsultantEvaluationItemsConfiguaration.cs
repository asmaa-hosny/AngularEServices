
using EservicesDomain.Domain.UCcompletion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.UCcompletion
{
  public  class ConsultantEvaluationItemsConfiguaration : IEntityTypeConfiguration<ConsultantEvaluationItems>
    {
        public void Configure(EntityTypeBuilder<ConsultantEvaluationItems> builder)
        {
            //builder.HasOne(x => x.ConsultationQuestions).
            //    WithMany(r => r.ConsultantEvaluationItems).
            //    HasForeignKey(x => x.QuestionId);

            builder.HasOne<ConsultantEvaluation>().
                WithMany(r => r.EvaluationItems).
                HasForeignKey(x => x.ConsultantEvaluationId);

            

            builder.ToTable("ConsultantEvaluationItems");
        }
    }
}
