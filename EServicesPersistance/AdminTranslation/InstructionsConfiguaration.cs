using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.AdminTranslation
{
   public class InstructionsConfiguaration : IEntityTypeConfiguration<EservicesDomain.Domain.AdTranslation.TranslationInstructions>
    {
        public void Configure(EntityTypeBuilder<EservicesDomain.Domain.AdTranslation.TranslationInstructions> builder)
        {
            builder.Property(x => x.InstructionsAR).HasColumnType("nvarchar(max)");
            builder.Property(x => x.InstructionsEN).HasColumnType("nvarchar(max)");
            builder.ToTable("Services_Instructions");
        }
    }
}
