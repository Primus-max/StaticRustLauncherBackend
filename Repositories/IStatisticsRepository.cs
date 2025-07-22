using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public interface IStatisticsRepository : IRepository<StatisticsData>
{
    Task<StatisticsData?> GetCurrentStatisticsAsync();
} 