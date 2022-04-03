using System.Text;
using Library.RadenRovcanin.API.Policies;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Data.Db.Repositories;
using Library.RadenRovcanin.Services;
using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            services.AddScoped<IAuthorizationHandler, AgeRequirementHandler>();
        }

        public static void ConfigureIdentityDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Person, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidIssuer = configuration["JWT:Issuer"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("18plus", policy => policy.AddRequirements(new AgeRequirement(18)));
            });
        }
    }
}
