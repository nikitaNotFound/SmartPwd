using SmartPwd.Clients.Application.StorageProviders.Contracts;
using SmartPwd.Clients.Application.StorageProviders.Extensions;

namespace SmartPwd.Clients.Application.StorageProviders;

public class StorageProviderContext
{
    private readonly IServiceProvider _sp;
    private readonly StorageProviderContextData _data;

    public StorageProviderContext(
        IServiceProvider sp,
        StorageProviderContextData data)
    {
        _sp = sp;
        _data = data;
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

    IStorageProvider GetLocalStorageProvider()
    {
        IStorageProvider? localStorageProvider = _sp.GetService(_data.LocalProvider) as IStorageProvider;
        if (localStorageProvider is null)
        {
            throw new Exception($"No registered providers for type {_data.LocalProvider}");
        }

        return localStorageProvider;
    }
}