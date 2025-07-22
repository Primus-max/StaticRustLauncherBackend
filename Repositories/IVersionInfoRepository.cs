using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public interface IVersionInfoRepository : IRepository<VersionInfo>
{
    Task<VersionInfo?> GetVersionInfoWithSftpAsync();
    Task<string> GetCurrentClientVersionAsync();
} 