using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public interface INewsRepository : IRepository<NewsItem>
{
    Task<IEnumerable<NewsItem>> GetRecentNewsAsync(int count);
} 