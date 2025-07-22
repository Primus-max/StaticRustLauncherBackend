namespace StaticRustLauncherBackend.Models;

public class VersionInfo
{
    public int Id { get; set; }
    public string? CurrentVersion { get; set; }
    public Dictionary<string, string>? Clients { get; set; }
    public List<SftpInfo>? SFTP { get; set; }
}

public class SftpInfo
{
    public int Id { get; set; }
    public int VersionInfoId { get; set; }
    public string? Host { get; set; }
    public int Port { get; set; }
    public string? User { get; set; }
    public string? Pass { get; set; }
    public VersionInfo VersionInfo { get; set; } = null!;
} 