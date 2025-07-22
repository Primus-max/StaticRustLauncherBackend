namespace StaticRustLauncherBackend.Models;

public class Server
{
    public int Id { get; set; }
    public string? Hostname { get; set; }
    public string? Map { get; set; }
    public int Players { get; set; }
    public int MaxPlayers { get; set; }
    public string? Tags { get; set; }
    public string? Ip { get; set; }
    public int Port { get; set; }
    public int QueryPort { get; set; }
    public string? Description { get; set; }
    public string? HeaderImage { get; set; }
    public string? Status { get; set; }
    public ServerUrl? Urls { get; set; }
}

public class ServerUrl
{
    public int Id { get; set; }
    public int ServerId { get; set; }
    public string? VK { get; set; }
    public string? Discord { get; set; }
    public string? Telegram { get; set; }
    public string? Steam { get; set; }
    public string? Site { get; set; }
    public Server Server { get; set; } = null!;
}

public enum ServerType
{
    Premium,
    Vip
}