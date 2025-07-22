using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public interface IHostingRepository : IRepository<Hosting>
{
    Task<IEnumerable<Hosting>> GetHostingsByTypeAsync(HostingType type);
} 