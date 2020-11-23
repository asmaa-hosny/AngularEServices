
using EservicesDomain.Domain.UC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EServicesPersistance.UCconsultation
{
   public class ConsultantAvailabilityConfiguaration : IEntityTypeConfiguration<ConsultantAvailability>
    {
        public void Configure(EntityTypeBuilder<ConsultantAvailability> builder)
        {

            builder.ToTable("ConsultantAvailability");
        }
    }
}
