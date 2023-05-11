using SmartPwd.Clients.Application.Models;
using SmartPwd.Clients.Application.StorageProviders.Contracts;

namespace SmartPwd.Clients.Application.StorageProviders;

public class StorageProviderContext
{
    private readonly IServiceProvider _sp;
    private readonly Dictionary<Type, Provider> _providersData;

    public StorageProviderContext(
        IServiceProvider sp,
        Dictionary<Type, Provider> providersData)
    {
        _sp = sp;
        _providersData = providersData;
    }

    TStorageProvider GetStorageProvider<TStorageProvider>()
        where TStorageProvider : class, IStorageProvider
    {
        var providerType = typeof(TStorageProvider);
        TStorageProvider? storageProvider = _sp.GetService(providerType) as TStorageProvider;
        if (storageProvider is null)
        {
            throw new Exception($"No registered providers for type {providerType}");
        }

        return storageProvider;
    }
}