using BrownOrchid.Services.BankEmployees.Data.Repositories;
using BrownOrchid.Services.BankEmployees.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Services.BankEmployees.Extensions;

public static class BankEmployeesDependencyInjection
{
    public static void AddBankEmployeesDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IBankEmployeeRepository, BankEmployeeRepository>();
    }
}