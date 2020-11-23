using EservicesDomain.Domain;
using EservicesDomain.Domain.ITGroupEmail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesPersistance.ITEmailGroup
{
    class EmailGroupMemberConfiguration : IEntityTypeConfiguration<EmailGroupMember>
    {
        public void Configure(EntityTypeBuilder<EmailGroupMember> builder)
        {
           
            builder.HasOne<EmailGroup>().WithMany(x => x.GroupMembers).HasForeignKey(x => x.AssociatedTo);

            builder.ToTable("IT_EmailGroup_Members");
        }
    }
}
