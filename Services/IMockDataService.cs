using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Services;

public interface IMockDataService
{
    List<Server> GetServers();
    List<Hosting> GetHostings();
    List<NewsItem> GetNews();
    StatisticsData GetStatistics();
    VersionInfo GetVersionInfo();
    string GetClientVersion();
} 