using Microsoft.Extensions.DependencyInjection;
using SmartPwd.Clients.Application.Models;
using SmartPwd.Clients.Application.StorageProviders.Contracts;

namespace SmartPwd.Clients.Application.StorageProviders.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddStorageProviderContext(
        this IServiceCollection services,
        Func<StorageProviderContextBuilder, StorageProviderContextData> builderFunc)
    {
        var data = builderFunc(new StorageProviderContextBuilder());

        foreach (KeyValuePair<Type,Provider> valuePair in data.ProvidersData)
        {
            services.AddScoped(typeof(IServiceProvider), valuePair.Key);
        }

        services.AddScoped(sp => new StorageProviderContext(sp, data));

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

    public StorageProviderContextData WithLocalProvider<TLocalStorageProvider>(Provider provider)
        where TLocalStorageProvider : class, IStorageProvider
    {
        if (!ProvidersData.TryAdd(typeof(TLocalStorageProvider), provider))
        {
            throw new Exception($"Unable to register storage provider for type {typeof(TLocalStorageProvider)}.");
        }

        return new StorageProviderContextData
        {
            LocalProvider = typeof(TLocalStorageProvider),
            ProvidersData = ProvidersData
        };
    }
}

public class StorageProviderContextData
{
    public required Dictionary<Type, Provider> ProvidersData { get; init; }

    public required Type LocalProvider { get; init; }
}