using Microsoft.Extensions.DependencyInjection;

namespace SmartPwd.Api.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddSmartPwdApiApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
        );

        return services;
    }
}