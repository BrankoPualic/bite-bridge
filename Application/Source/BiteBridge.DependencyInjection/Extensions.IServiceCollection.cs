using FluentValidation;
using BiteBridge.Application.BusinessLogic._Base;
using BiteBridge.Application.BusinessLogic._Behaviors;
using BiteBridge.Application.Identity.Interfaces;
using BiteBridge.Application.Identity.Services;
using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BiteBridge.Common.Interfaces;
using BiteBridge.Infrastructure.Logger;

namespace BiteBridge.DependencyInjection;

public static partial class Extensions
{
    public static IServiceCollection AllApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var secrets = CreateSecretConfiguration();

        PersistenceServices(services, secrets);
        ApplicationServices(services);
        IdentityServices(services, configuration, secrets);
        InfrastructureServices(services, configuration);

        return services;
    }

    private static IServiceCollection ApplicationServices(IServiceCollection services)
    {
        var assembly = typeof(BaseHandler<>).Assembly;

        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(assembly);

        ApplicationPipelineBehaviors(services);

        return services;
    }

    private static IServiceCollection IdentityServices(IServiceCollection services, IConfiguration configuration, IConfiguration secrets)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(secrets["JWT_KEY"]!)),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

    private static IServiceCollection PersistenceServices(IServiceCollection services, IConfiguration secrets)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(secrets["LOCAL_DEV_DB_CONNECTION"]));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
	private static IServiceCollection InfrastructureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddTransient<IExceptionLogger, DbExceptionLogger>();
		return services;
	}

	private static IServiceCollection ApplicationPipelineBehaviors(IServiceCollection services)
	{
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceMonitoringBehavior<,>));

        return services;
    }

    private static IServiceCollection ApplicationPipelineBehaviors(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceMonitoringBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        return services;
    }
}