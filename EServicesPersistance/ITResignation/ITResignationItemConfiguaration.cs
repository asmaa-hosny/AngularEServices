using EservicesDomain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EServicesPersistance.ITResignation
{
    public class ITResignationItemConfiguaration : IEntityTypeConfiguration<ITResignationItem>
    {
        public void Configure(EntityTypeBuilder<ITResignationItem> builder)
        {
            builder.Property(x => x.ItemAR).HasMaxLength(50);
            builder.Property(x => x.ItemEN).HasMaxLength(50);
            builder.Property(x => x.NodeId).HasColumnName("Node_Id");
            builder.ToTable("IT_Resignation_Items");
        }
    }
}
