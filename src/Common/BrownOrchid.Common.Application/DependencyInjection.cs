using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Common.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(assemblies);
        services.AddValidatorsFromAssemblies(assemblies);
        services.AddAutoMapper(assemblies);
        
        return services;
    }
}