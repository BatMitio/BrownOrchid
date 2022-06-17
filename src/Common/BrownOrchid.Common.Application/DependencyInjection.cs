using System.Reflection;
using BrownOrchid.Common.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BrownOrchid.Common.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(assemblies);
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblies(assemblies);
        services.AddAutoMapper(assemblies);
        
        return services;
    }
}