using OurCheck.API;
using OurCheck.Application;
using OurCheck.Infrastructure;
using OurCheck.Persistence.EF;
using OurCheck.Persistence.EF.Db;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

builder.AddApplicationServices();
builder.AddInfrastructureServices();
builder.AddPersistenceServices();
builder.AddApiServices();

var app = builder.Build();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 
await app.InitialiseDatabaseAsync();

app.Run();