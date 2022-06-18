using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Worker;
using BrownOrchid.Services.DWH.Data.Persistence;
using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);
//
// builder.AddPersistence();
// var app = builder.Build();
// app.EnsureDatabaseCreated();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        //
        //App db
        var appOptions = new DbContextOptionsBuilder<AppDbContext>();
        appOptions.UseSqlServer(configuration.GetConnectionString("AppDb"));
        services.AddTransient(d => new AppDbContext(appOptions.Options));
        
        //DWH db
        var dwhOptions = new DbContextOptionsBuilder<DwhDbContext>();
        dwhOptions.UseSqlServer(configuration.GetConnectionString("DwhDb"));
        services.AddTransient(d => new DwhDbContext(dwhOptions.Options));
        

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();