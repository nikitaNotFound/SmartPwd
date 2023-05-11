namespace SmartPwd.Clients.Application.Models;

public class Provider
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}