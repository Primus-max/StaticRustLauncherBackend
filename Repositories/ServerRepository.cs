using Microsoft.EntityFrameworkCore;
using StaticRustLauncherBackend.Data;
using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public class ServerRepository : Repository<Server>, IServerRepository
{
    public ServerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Server>> GetServersWithUrlsAsync()
    {
        return await _dbSet
            .Include(s => s.Urls)
            .ToListAsync();
    }

    public async Task<Server?> GetServerWithUrlsAsync(int id)
    {
        return await _dbSet
            .Include(s => s.Urls)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
} 