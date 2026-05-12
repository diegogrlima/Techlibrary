using BibliotecaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaApp.Infrastructure.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Author)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Biography)
                .HasMaxLength(1000);

            builder.Property(x => x.PublicationDate)
                .IsRequired();

            builder.Property(x => x.Isbn)
                .HasMaxLength(20);

            builder.Property(x => x.PageCount);

            builder.Property(x => x.CoverUrl)
                .HasMaxLength(500);

            builder.Property(x => x.OpenLibraryKey)
                .HasMaxLength(100);
        }
    }
}