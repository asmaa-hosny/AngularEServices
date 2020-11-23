using EservicesDomain.Domain.DomainAgility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.TotalAgility
{
    public class AllRequestsConfiguaration : IEntityTypeConfiguration<AllRequests>
    {
        public void Configure(EntityTypeBuilder<AllRequests> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.Job_Finish_Time).HasColumnName("Job Finish Time");
            builder.Property(x => x.Employee_Name).HasColumnName("Employee Name");
            builder.Property(x => x.Request_Date).HasColumnName("Request Date");

            builder.ToView("View_AllRequests");
        }
    }

  



}
