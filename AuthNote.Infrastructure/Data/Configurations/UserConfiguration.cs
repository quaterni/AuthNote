using AuthNote.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user=> user.Id);

            builder.HasIndex(user => user.Email).IsUnique();

            builder.Property(user => user.FirstName);

            builder.HasMany(user => user.Notes)
                .WithOne(note=> note.User);
        }
    }
}
