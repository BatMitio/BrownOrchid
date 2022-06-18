using BrownOrchid.Services.Clients.Data.Repositories;
using BrownOrchid.Services.Clients.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Services.Clients.Extensions;

public static class ClientsDependencyInjection
{
    public static void AddClientsDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IClientRepository, ClientRepository>();
    }
}