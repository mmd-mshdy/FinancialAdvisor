using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using Microsoft.Extensions.DependencyInjection;
using FinAdvisor.Modules.Identity.Infrastructure.Authentication;

namespace FinAdvisor.Modules.Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}