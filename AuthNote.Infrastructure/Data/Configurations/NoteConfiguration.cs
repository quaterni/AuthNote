using AuthNote.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthNote.Infrastructure.Data.Configurations
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("notes");

            builder.HasKey(note=> note.Id);

            builder.Property(note=> note.Title).IsRequired();

            builder.Property(note=> note.Content).IsRequired();

            builder.HasOne(note => note.User)
                .WithMany(user => user.Notes);

        }
    }
}
