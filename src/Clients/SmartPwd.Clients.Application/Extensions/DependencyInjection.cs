using Microsoft.Extensions.DependencyInjection;
using SmartPwd.Clients.Application.ViewModels;

namespace SmartPwd.Clients.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddViewModels(
        this IServiceCollection services)
    {
        services.AddScoped<CreateVaultViewModel>();
        services.AddScoped<VaultsManagerViewModel>();
        services.AddScoped<VaultViewModel>();

        return services;
    }
}