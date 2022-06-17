using BrownOrchid.Services.DWH.BankEmployees.Data.Entities;
using BrownOrchid.Services.DWH.Dealers.Data.Entities;
using BrownOrchid.Services.DWH.Dealers.Data.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Services.DWH.BankEmployees.Extensions;

public static class IdentityExtensions
{
    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<BankEmployee, IdentityRole>()
            .AddEntityFrameworkStores<DealerDbContext>()
            .AddDefaultTokenProviders();
    }
}