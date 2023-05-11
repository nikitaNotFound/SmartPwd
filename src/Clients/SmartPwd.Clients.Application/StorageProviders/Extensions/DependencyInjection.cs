using Microsoft.Extensions.DependencyInjection;
using SmartPwd.Clients.Application.Models;
using SmartPwd.Clients.Application.StorageProviders.Contracts;

namespace SmartPwd.Clients.Application.StorageProviders.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddStorageProviderContext(
        this IServiceCollection services,
        Func<StorageProviderContextBuilder, StorageProviderContextBuilder> builderFunc)
    {
        var builder = builderFunc(new StorageProviderContextBuilder());

        foreach (KeyValuePair<Type,Provider> valuePair in builder.ProvidersData)
        {
            services.AddScoped(typeof(IServiceProvider), valuePair.Key);
        }

        services.AddScoped(sp => new StorageProviderContext(sp, builder.ProvidersData));

        return services;
    }
}

public class StorageProviderContextBuilder
{
    public readonly Dictionary<Type, Provider> ProvidersData = new();

    public StorageProviderContextBuilder AddStorageProvider<TStorageProvider>(Provider provider)
        where TStorageProvider : class, IStorageProvider
    {
        if (!ProvidersData.TryAdd(typeof(TStorageProvider), provider))
        {
            throw new Exception($"Unable to register storage provider for type {typeof(TStorageProvider)}.");
        }

        return this;
    }
}