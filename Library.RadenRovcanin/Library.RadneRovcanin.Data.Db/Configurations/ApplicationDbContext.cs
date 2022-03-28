using System.Reflection;
using Library.RadenRovcanin.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.RadneRovcanin.Data.Db.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; } = default!;
        public DbSet<Address> Address { get; set; } = default!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
