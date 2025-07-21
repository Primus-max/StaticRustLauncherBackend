using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Services;

public class MockDataService : IMockDataService
{
    public List<Server> GetServers()
    {
        return new List<Server>
        {
            new Server
            {
                Hostname = "Rust Premium Server #1",
                Map = "Procedural Map",
                Players = 85,
                MaxPlayers = 150,
                Tags = "PVP, Raid, Active Admins",
                Ip = "192.168.1.100",
                Port = 28015,
                QueryPort = 28016,
                Description = "Премиум сервер с активной администрацией и регулярными событиями",
                HeaderImage = "https://example.com/server1.jpg",
                Status = "premium",
                Urls = new List<ServerUrl>
                {
                    new ServerUrl
                    {
                        VK = "https://vk.com/rustserver1",
                        Discord = "https://discord.gg/rustserver1",
                        Telegram = "https://t.me/rustserver1",
                        Steam = "https://steamcommunity.com/groups/rustserver1",
                        Site = "https://rustserver1.com"
                    }
                }
            },
            new Server
            {
                Hostname = "Rust VIP Server #2",
                Map = "Custom Map",
                Players = 120,
                MaxPlayers = 200,
                Tags = "VIP, Events, Custom Plugins",
                Ip = "192.168.1.101",
                Port = 28017,
                QueryPort = 28018,
                Description = "VIP сервер с кастомными плагинами и регулярными турнирами",
                HeaderImage = "https://example.com/server2.jpg",
                Status = "vip",
                Urls = new List<ServerUrl>
                {
                    new ServerUrl
                    {
                        VK = "https://vk.com/rustserver2",
                        Discord = "https://discord.gg/rustserver2",
                        Telegram = "https://t.me/rustserver2",
                        Steam = "https://steamcommunity.com/groups/rustserver2",
                        Site = "https://rustserver2.com"
                    }
                }
            },
            new Server
            {
                Hostname = "Rust Regular Server #3",
                Map = "Procedural Map",
                Players = 45,
                MaxPlayers = 100,
                Tags = "Regular, PVP, Vanilla",
                Ip = "192.168.1.102",
                Port = 28019,
                QueryPort = 28020,
                Description = "Обычный сервер для спокойной игры",
                HeaderImage = "https://example.com/server3.jpg",
                Status = "regular",
                Urls = new List<ServerUrl>
                {
                    new ServerUrl
                    {
                        VK = "https://vk.com/rustserver3",
                        Discord = "https://discord.gg/rustserver3",
                        Telegram = "https://t.me/rustserver3",
                        Steam = "https://steamcommunity.com/groups/rustserver3",
                        Site = "https://rustserver3.com"
                    }
                }
            }
        };
    }

    public List<Hosting> GetHostings()
    {
        return new List<Hosting>
        {
            new Hosting
            {
                Name = "Premium Hosting",
                Description = "Премиум хостинг с максимальной производительностью",
                Image = "https://example.com/premium-hosting.jpg",
                Users = 1500,
                Projects = 50,
                Url = "https://premium-hosting.com",
                Status = 0 // OurChoice
            },
            new Hosting
            {
                Name = "Reliable Hosting",
                Description = "Надежный хостинг с отличным соотношением цена/качество",
                Image = "https://example.com/reliable-hosting.jpg",
                Users = 800,
                Projects = 25,
                Url = "https://reliable-hosting.com",
                Status = 1 // Reliable
            }
        };
    }

    public List<NewsItem> GetNews()
    {
        return new List<NewsItem>
        {
            new NewsItem
            {
                Title = "Обновление клиента до версии 2.1",
                Description = "Вышло новое обновление клиента с исправлениями багов и улучшениями производительности",
                Image = "https://example.com/news1.jpg",
                DateCreate = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd")
            },
            new NewsItem
            {
                Title = "Новый сервер Premium",
                Description = "Запущен новый премиум сервер с увеличенным лимитом игроков",
                Image = "https://example.com/news2.jpg",
                DateCreate = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd")
            },
            new NewsItem
            {
                Title = "Турнир на выходных",
                Description = "В эти выходные состоится турнир с призовым фондом",
                Image = "https://example.com/news3.jpg",
                DateCreate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
            }
        };
    }

    public StatisticsData GetStatistics()
    {
        return new StatisticsData
        {
            UsersOnline = 1250,
            ServersCount = 15
        };
    }

    public VersionInfo GetVersionInfo()
    {
        return new VersionInfo
        {
            CurrentVersion = "2.1.0",
            Clients = new Dictionary<string, string>
            {
                { "actual", "2.1.0" },
                { "333", "1.9.5" },
                { "12333", "1.8.2" }
            },
            SFTP = new List<SftpInfo>
            {
                new SftpInfo
                {
                    Host = "sftp.hoster.by",
                    Port = 22,
                    User = "user2120",
                    Pass = "uT3cB1xE1r"
                }
            }
        };
    }

    public string GetClientVersion()
    {
        return "2.1.0";
    }
} 