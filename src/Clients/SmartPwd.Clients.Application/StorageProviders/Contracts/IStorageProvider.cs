using SmartPwd.Clients.Application.Models;

namespace SmartPwd.Clients.Application.StorageProviders.Contracts;

public interface IStorageProvider
{
    Task CreateVaultAsync(Vault vault);

    Task DeleteVaultAsync(Guid vaultId);

    Task<List<Vault>> GetVaultsAsync();
}