using Microsoft.EntityFrameworkCore;
using StaticRustLauncherBackend.Data;
using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public class StatisticsRepository : Repository<StatisticsData>, IStatisticsRepository
{
    public StatisticsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<StatisticsData?> GetCurrentStatisticsAsync()
    {
        return await _dbSet.FirstOrDefaultAsync();
    }
} 