
using BuberDinner.Application.Interfaces;
using BuberDinner.Application.Interfaces.Auth;
using BuberDinner.Application.Interfaces.Users;
using BuberDinner.Infrastructure.Data.Repositories.Users;
using BuberDinner.Infrastructure.Identity;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Persistence.Repositories;
using BuberDinner.Infrastructure.Providers;
using BuberDinner.Infrastructure.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwtBearerAuth(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        services.AddScoped<IUserRepository2, UserRepository2>();

        services.AddScoped<IRepositoryManager, RepositoryManager>();

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddAuthIdentityRequirement();

        return services;
    }

    private static IServiceCollection AddJwtBearerAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        // services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication( options => 
        { 
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        })
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });

        return services;
    }
}