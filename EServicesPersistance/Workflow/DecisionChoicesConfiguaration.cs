using EservicesDomain.Common;
using EservicesDomain.Domain.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace EServicesPersistance.Workflow
{
    public class DecisionChoicesConfiguaration : IEntityTypeConfiguration<DecisionChoices>
    {
    
        public void Configure(EntityTypeBuilder<DecisionChoices> builder)
        {

            builder.HasNoKey();
            builder.Ignore(x=>x.Id);
            builder.ToView("view_DecisionChoices");
         

        }
    }

}
