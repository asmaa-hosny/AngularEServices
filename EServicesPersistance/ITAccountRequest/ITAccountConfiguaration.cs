using EservicesDomain.Common;
using EservicesDomain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.ITAccountRequest
{
    public class ITCareConfiguaration : BaseEntityMap<ITAccount,int>
    {
        public override void Configure(EntityTypeBuilder<ITAccount> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Justification).IsRequired();
            builder.Property(x => x.EmployeeEmail).IsRequired();
            builder.Property(x => x.IsWithEmail).IsRequired();
            builder.Property(x => x.IsForTrainee).IsRequired();
            builder.Property(x => x.RefId).HasComputedColumnSql<string>("([dbo].[GenerateIT_SYS_REFID]([id]))");
            builder.Ignore(x=>x.NodeID);
            builder.ToTable("IT_UserAndEmailRequest");
        }
    }


   
}
