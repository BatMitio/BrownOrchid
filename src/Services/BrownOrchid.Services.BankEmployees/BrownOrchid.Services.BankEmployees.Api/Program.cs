using BrownOrchid.Common.Application;
using BrownOrchid.Common.Application.Extensions;
using BrownOrchid.Services.BankEmployees.Api;
using BrownOrchid.Services.BankEmployees.Data.Persistence;
using BrownOrchid.Services.BankEmployees.Extensions;
using BrownOrchid.Services.DWH.Data.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddPersistence();
builder.Services.AddApplication(new[] { typeof(BankEmployeesDependencyInjection).Assembly });
builder.Services.AddBankEmployeesDependencyInjection();
builder.AddSecurity();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        //
        //Employee db
        var appOptions = new DbContextOptionsBuilder<BankEmployeesDbContext>();
        appOptions.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDb"));
        services.AddTransient(d => new BankEmployeesDbContext(appOptions.Options));
        
        //DWH db
        var dwhOptions = new DbContextOptionsBuilder<DwhDbContext>();
        dwhOptions.UseSqlServer(builder.Configuration.GetConnectionString("DwhDb"));
        services.AddTransient(d => new DwhDbContext(dwhOptions.Options));
        services.AddHostedService<Worker>();
    })
    .Build();

host.RunAsync();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.EnsureDatabaseCreated();
app.UseSecurity();
app.MapControllers();

app.Run();