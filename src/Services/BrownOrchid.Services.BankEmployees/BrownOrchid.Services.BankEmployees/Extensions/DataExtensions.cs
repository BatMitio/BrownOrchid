using BrownOrchid.Services.BankEmployees.Data.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Services.BankEmployees.Extensions;

public static class DataExtensions
{
    public static void AddPersistence(this WebApplicationBuilder builder, string name = "Database")
    {
        var connectionString = builder.Configuration.GetConnectionString(name);
        builder.Services.AddDbContext<BankEmployeesDbContext>(opt =>
            opt.UseSqlServer(connectionString));
    }

    public static void EnsureDatabaseCreated(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<BankEmployeesDbContext>();
        db!.Database.EnsureCreated();
    }
}