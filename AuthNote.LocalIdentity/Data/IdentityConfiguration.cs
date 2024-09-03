using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.LocalIdentity.Data
{
    internal class IdentityConfiguration : IEntityTypeConfiguration<Identity>
    {
        public void Configure(EntityTypeBuilder<Identity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired();

            builder.Property(x => x.PasswordHash).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
