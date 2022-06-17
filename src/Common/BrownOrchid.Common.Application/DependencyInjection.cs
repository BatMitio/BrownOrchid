using System.Reflection;
using BrownOrchid.Common.Application.Behaviours;
using BrownOrchid.Common.Application.Jwt;
using BrownOrchid.Common.Application.Jwt.Interfaces;
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
        services.AddTransient<ITokenGenerator, TokenGenerator>();
        services.AddValidatorsFromAssemblies(assemblies);
        services.AddAutoMapper(assemblies);
        
        return services;
    }
}