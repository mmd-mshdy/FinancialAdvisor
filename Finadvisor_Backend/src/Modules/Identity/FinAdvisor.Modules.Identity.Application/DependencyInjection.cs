using FinAdvisor.BuildingBlocks.Application.Behaviors;
using FinAdvisor.BuildingBlocks.Application.Validation;
using FinAdvisor.Modules.Identity.Application.Users.Login;
using FinAdvisor.Modules.Identity.Application.Users.Register;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinAdvisor.Modules.Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(
                typeof(AssemblyReference).Assembly);

            configuration.AddOpenBehavior(
                typeof(ValidationBehavior<,>));
        });
        services.AddScoped<
    IValidator<RegisterUserCommand>,
    RegisterUserCommandValidator>();

        services.AddScoped<
            IValidator<LoginUserCommand>,
            LoginUserCommandValidator>();

        return services;
    }
}