using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Contracts.Settings;
using Library.RadenRovcanin.Data.Db.Repositories;
using Library.RadenRovcanin.Services;
using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Library.RadenRovcanin.Functions.Startup))]
namespace Library.RadenRovcanin.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<ILibraryNotificationService, LibraryNotificationService>();

            var p = builder.GetContext().Configuration;
            builder.Services.Configure<EmailSettings>(p.GetSection("EmailSettings"));
            var connectionString = p.GetConnectionString("LibraryDB");

            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
    }
}
