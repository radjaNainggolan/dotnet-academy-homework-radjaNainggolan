using Library.RadenRovcanin.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.RadneRovcanin.Data.Db.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Age);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasMany(p => p.RentedBooks)
                .WithMany(b => b.People)
                .UsingEntity<Dictionary<string, object>>(
                "PersonBook",
                b => b.HasOne<Book>().WithMany().HasForeignKey("BookdId"),
                p => p.HasOne<Person>().WithMany().HasForeignKey("PersonId"));
        }
    }
}
