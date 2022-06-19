using BrownOrchid.Common.Application;
using BrownOrchid.Common.Application.Extensions;
using BrownOrchid.Services.App.Api;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Extensions;
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

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Dealer",
        policy => policy.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "dealer"));
    options.AddPolicy("Employee",
        policy => policy.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "employee"));
});


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



IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        //
        //App db
        var appOptions = new DbContextOptionsBuilder<AppDbContext>();
        appOptions.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"));
        services.AddTransient(d => new AppDbContext(appOptions.Options));

        //DWH db
        var dwhOptions = new DbContextOptionsBuilder<DwhDbContext>();
        dwhOptions.UseSqlServer(builder.Configuration.GetConnectionString("DwhDb"));
        services.AddTransient(d => new DwhDbContext(dwhOptions.Options));

        services.AddHostedService<Worker>();
    })
    .Build();

host.RunAsync();

app.Run();