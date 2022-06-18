using BrownOrchid.Services.BankEmployees.Data.Persistence;
using BrownOrchid.Services.BankEmployees.Worker;
using BrownOrchid.Services.DWH.Data.Persistence;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        //
        //Employee db
        var appOptions = new DbContextOptionsBuilder<BankEmployeesDbContext>();
        appOptions.UseSqlServer(configuration.GetConnectionString("EmployeeDb"));
        services.AddTransient(d => new BankEmployeesDbContext(appOptions.Options));
        
        //DWH db
        var dwhOptions = new DbContextOptionsBuilder<DwhDbContext>();
        dwhOptions.UseSqlServer(configuration.GetConnectionString("DwhDb"));
        services.AddTransient(d => new DwhDbContext(dwhOptions.Options));
        
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();