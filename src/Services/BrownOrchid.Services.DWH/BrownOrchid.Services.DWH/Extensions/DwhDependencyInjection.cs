using BrownOrchid.Services.DWH.Data.Persistence;
using BrownOrchid.Services.DWH.Data.Persistence.Interfaces;
using BrownOrchid.Services.DWH.Data.Repositories;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Services.DWH.Extensions;

public static class DwhDependencyInjection
{
    public static void AddDwhDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IDwhDbContext, DwhDbContext>();
        serviceCollection.AddTransient<IDealerRepository, DealerRepository>();
        serviceCollection.AddTransient<IBankEmployeeRepository, BankEmployeeRepository>();
        serviceCollection.AddTransient<IPosTerminalRepository, PosTerminalRepository>();
    }
}