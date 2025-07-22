using Microsoft.EntityFrameworkCore;
using StaticRustLauncherBackend.Data;
using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public class HostingRepository : Repository<Hosting>, IHostingRepository
{
    public HostingRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Hosting>> GetHostingsByTypeAsync(HostingType type)
    {
        return await _dbSet
            .Where(h => h.HostingType == type)
            .ToListAsync();
    }
} 