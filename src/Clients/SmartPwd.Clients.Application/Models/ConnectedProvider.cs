namespace SmartPwd.Clients.Application.Models;

public class ConnectedProvider
{
    public required Provider Info { get; set; }

    public required Dictionary<string, string> Parameters { get; set; }
}