using EservicesDomain.Domain.UCcompletion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.UCcompletion
{
    public class ConsultationQuestionsConfiguaration : IEntityTypeConfiguration<ConsultationQuestions>
    {
        public void Configure(EntityTypeBuilder<ConsultationQuestions> builder)
        {
            builder.ToTable("ConsultationQuestions");
        }
    }
}
