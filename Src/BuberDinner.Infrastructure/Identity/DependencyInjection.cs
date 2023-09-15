using BuberDinner.Infrastructure.Persistence;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDinner.Infrastructure.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthIdentityRequirement(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredLength = 5;

            options.SignIn.RequireConfirmedAccount = true;

        }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanCreateUserPolicy",
                policy => policy.RequireClaim("add-user")
            );
        });

        return services;
    }
}