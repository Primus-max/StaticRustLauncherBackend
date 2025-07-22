using Microsoft.EntityFrameworkCore;
using StaticRustLauncherBackend.Data;
using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Repositories;

public class VersionInfoRepository : Repository<VersionInfo>, IVersionInfoRepository
{
    public VersionInfoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<VersionInfo?> GetVersionInfoWithSftpAsync()
    {
        return await _dbSet
            .Include(v => v.SFTP)
            .FirstOrDefaultAsync();
    }

    public async Task<string> GetCurrentClientVersionAsync()
    {
        var versionInfo = await _dbSet.FirstOrDefaultAsync();
        return versionInfo?.CurrentVersion ?? "1.0.0";
    }
} 