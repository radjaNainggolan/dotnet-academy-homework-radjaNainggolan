using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Data.Db.Repositories;
using Library.RadenRovcanin.Services;
using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.API
{
    public static class IoC
    {
        public static void ConfigureDatabaseDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                opt =>
                {
                    opt.UseSqlServer(
                        configuration.GetConnectionString("LibraryDB"),
                        opt => opt.MigrationsAssembly("Library.RadenRovcanin.Data.Db"));
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureServicesDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("JWT"));

            services.AddScoped<UserManager<Person>>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IRegistrationService, RegistrationService>();
        }
    }
}
