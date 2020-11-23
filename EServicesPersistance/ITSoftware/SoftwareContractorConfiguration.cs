using EservicesDomain.Domain.ITSoftware;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesPersistance.ITSoftware
{
    public class SoftwareContractorConfiguration : IEntityTypeConfiguration<SoftwareContractor>
    {
        public void Configure(EntityTypeBuilder<SoftwareContractor> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn<int>(1);
            builder.Property(x => x.ContractorName).HasMaxLength(500);
            builder.Property(x => x.ContractorProject).HasMaxLength(500);
            builder.Property(x => x.ContractorEmail).HasMaxLength(500);
            builder.Property(x => x.ContractorCompany).HasMaxLength(500);
            builder.Property(x => x.ContractorPhone).HasMaxLength(500);


            builder.ToTable("IT_Software_Contractor");
        }
    }
}
