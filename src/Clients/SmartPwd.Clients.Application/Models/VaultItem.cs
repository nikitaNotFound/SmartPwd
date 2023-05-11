namespace SmartPwd.Clients.Application.Models;

public class VaultItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public VaultItemType Type { get; set; }

    public Dictionary<string, string> Parameters { get; set; } = new();
}