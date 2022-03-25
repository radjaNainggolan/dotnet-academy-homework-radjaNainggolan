using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.API
{
    public static class IoC
    {
        public static void ConfigureDepengencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                opt =>
                {
                    opt.UseSqlServer(
                        configuration.GetConnectionString("LibraryDB"),
                        opt => opt.MigrationsAssembly("Library.RadenRovcanin.Data.Db"));
                });
        }
    }
}
