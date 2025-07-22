using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public interface IServerRepository : IRepository<Server>
{
    Task<IEnumerable<Server>> GetServersWithUrlsAsync();
    Task<Server?> GetServerWithUrlsAsync(int id);
} 