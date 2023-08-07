using Application.User.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Users;
public static class ConfigUserHandlers
{
    public static IServiceCollection RegisterUserHandlers(
        this IServiceCollection services)
    {
        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ConfigUserHandlers).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });
    }
}
