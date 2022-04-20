using Library.RadenRovcanin.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.RadenRovcanin.Data.Db.Configurations
{
    public class PersonBookConfiguration : IEntityTypeConfiguration<PersonBook>
    {
        public void Configure(EntityTypeBuilder<PersonBook> builder)
        {
            builder.HasKey(t => new { BookId = t.BookId, PersonId = t.PersonId });

            builder
                .Property(p => p.DateRented)
                .IsRequired();

            builder
                .HasOne(p => p.Person)
                .WithMany(p => p.RentedBooks)
                .HasForeignKey("PersonId");

            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.PersonBooks)
                .HasForeignKey("BookId");
        }
    }
}
