using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Contracts.Settings;
using Library.RadenRovcanin.Data.Db.Repositories;
using Library.RadenRovcanin.Services;
using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library.RadenRovcanin.Functions
{
    public class Program
    {
        private static IConfiguration config = default!;

        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureAppConfiguration(builder =>
                {
                    config = builder
                    .AddJsonFile("local.settings.json", true)
                    .Build();
                })
                .ConfigureServices(service =>
                {
                    service.Configure<EmailSettings>(
                        config.GetSection("EmailSettings"));
                    service.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("LibraryDB")));
                    service.AddScoped<ILibraryNotificationService, LibraryNotificationService>();
                    service.AddScoped<IEmailService, EmailService>();
                    service.AddScoped<IUnitOfWork, UnitOfWork>();
                })
                .Build();
            host.Run();
        }
    }
}
