using BrownOrchid.Services.App.Data.Repositories;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Services.App.Extensions;

public static class BankEmployeesDependencyInjection
{
    public static void AddBankEmployeesDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IDealerRepository, DealerRepository>();
        serviceCollection.AddTransient<IDiscountRepository, DiscountRepository>();
        serviceCollection.AddTransient<IPosTerminalRepository, PosTerminalRepository>();
        serviceCollection.AddTransient<IApprovalRepository, ApprovalRepository>();
    }
}