namespace StaticRustLauncherBackend.Models;

public class VersionInfo
{
    public string? CurrentVersion { get; set; }
    public Dictionary<string, string>? Clients { get; set; }
    public List<SftpInfo>? SFTP { get; set; }
}

public class SftpInfo
{
    public string? Host { get; set; }
    public int Port { get; set; }
    public string? User { get; set; }
    public string? Pass { get; set; }
} 