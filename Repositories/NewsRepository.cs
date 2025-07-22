using Microsoft.EntityFrameworkCore;
using StaticRustLauncherBackend.Data;
using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public class NewsRepository : Repository<NewsItem>, INewsRepository
{
    public NewsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<NewsItem>> GetRecentNewsAsync(int count)
    {
        return await _dbSet
            .OrderByDescending(n => n.DateCreate)
            .Take(count)
            .ToListAsync();
    }
} 