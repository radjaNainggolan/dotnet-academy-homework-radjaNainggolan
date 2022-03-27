using Library.RadenRovcanin.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.RadneRovcanin.Data.Db.Configurations
{
    public class AddresConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasOne(a => a.Person)
                .WithOne(p => p.Address)
                .HasForeignKey<Person>(p => p.Id);

            builder
                .Property(a => a.Street)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a => a.City)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a => a.Country)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
