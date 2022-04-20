using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Data.Db.Repositories;
using Library.RadenRovcanin.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
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
        }
    }
}
