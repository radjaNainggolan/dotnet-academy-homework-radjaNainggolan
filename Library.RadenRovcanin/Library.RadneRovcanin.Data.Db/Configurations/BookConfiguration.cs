using Library.RadenRovcanin.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.RadenRovcanin.Data.Db.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(b => b.Genre)
                .IsRequired();

            builder
                .Property(b => b.Authors)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(b => b.Quantity)
                .IsRequired();
        }
    }
}
