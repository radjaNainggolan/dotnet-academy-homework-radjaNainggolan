using Library.RadenRovcanin.API;
using Library.RadenRovcanin.API.CustomMiddleware;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Data.Db.Repositories;
using Library.RadenRovcanin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
IoC.ConfigureDatabaseDependencies(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCustomMiddleware();

app.Run();
