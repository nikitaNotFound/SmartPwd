using SmartPwd.Clients.Application.Models;

namespace SmartPwd.Clients.Application.StorageProviders.Contracts;

public interface ILocalStorageProvider : IStorageProvider
{
    Task AddConnectedProviderAsync(ConnectedProvider connectedProvider);

    Task DeleteConnectedProviderAsync(string providerId);

    Task<List<ConnectedProvider>> GetConnectedProvidersAsync();
}