using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.AdminTranslation
{
   public class AdminTranslatorConfiguaration : IEntityTypeConfiguration<EservicesDomain.Domain.AdTranslation.AdminTranslator>
    {
        public void Configure(EntityTypeBuilder<EservicesDomain.Domain.AdTranslation.AdminTranslator> builder)
        {

            builder.ToTable("Admin_Translator");
        }
    }
}
