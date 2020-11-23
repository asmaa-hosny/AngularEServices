using EservicesDomain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace EServicesPersistance
{
    public class ITResignationConfiguaration : BaseEntityMap<EservicesDomain.Domain.ITResignation, int>
    {
        public override void Configure(EntityTypeBuilder<EservicesDomain.Domain.ITResignation> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.EmployeeEmail).HasMaxLength(50);
            builder.Property(x => x.EmployeeName).HasMaxLength(50);
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateIT_Resignation_REFID]([id]))");
            builder.Ignore(x => x.NodeID);
            builder.ToTable("IT_Resignation");
        }
    }
}
