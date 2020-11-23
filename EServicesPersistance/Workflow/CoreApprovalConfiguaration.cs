using EservicesDomain.Common;
using EservicesDomain.Domain.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.Workflow
{
    public class CoreApprovalConfiguaration : BaseEntityMap<CoreApproval, int>
    {
        public override void Configure(EntityTypeBuilder<CoreApproval> builder)
        {
            base.Configure(builder);
            
            builder.Property(e => e.Role).HasMaxLength(50).IsRequired();
            builder.Property(e => e.NodeID).HasColumnName("NodeID");
            builder.Property(e => e.JobId).HasColumnName("JOB ID").HasMaxLength(50);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Comment).HasMaxLength(1000).IsRequired();
            builder.Ignore(e => e.RefId);
            builder.ToTable("Core_Approvals");
        }
    }

}
