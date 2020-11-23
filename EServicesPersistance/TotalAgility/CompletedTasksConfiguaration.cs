using EservicesDomain.Domain.DomainAgility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.TotalAgility
{
    public class CompletedTasksConfiguaration : IEntityTypeConfiguration<CompletedTasks>
    {
        public void Configure(EntityTypeBuilder<CompletedTasks> builder)
        {
            builder.HasNoKey();
            builder.ToView("CompletedTasks_view");
        }
    }

  



}
