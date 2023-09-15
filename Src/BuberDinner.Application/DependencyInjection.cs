using BuberDinner.Application.Behaviors;
using BuberDinner.WebApi.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // services.AddScoped<IValidator<Register.Command>, RegisterValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
       
        return services;
    }
}