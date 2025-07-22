using Microsoft.EntityFrameworkCore;
using StaticRustLauncherBackend.Data;
using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Services;

public class DataSeedService : IDataSeedService
{
    private readonly ApplicationDbContext _context;

    public DataSeedService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedDataAsync()
    {
        // Проверяем, есть ли уже данные
        if (await _context.Servers.AnyAsync())
        {
            return; // Данные уже есть
        }

        // Создаем серверы
        var servers = new List<Server>
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
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver1",
                    Discord = "https://discord.gg/rustserver1",
                    Telegram = "https://t.me/rustserver1",
                    Steam = "https://steamcommunity.com/groups/rustserver1",
                    Site = "https://rustserver1.com"
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
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver2",
                    Discord = "https://discord.gg/rustserver2",
                    Telegram = "https://t.me/rustserver2",
                    Steam = "https://steamcommunity.com/groups/rustserver2",
                    Site = "https://rustserver2.com"
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
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver3",
                    Discord = "https://discord.gg/rustserver3",
                    Telegram = "https://t.me/rustserver3",
                    Steam = "https://steamcommunity.com/groups/rustserver3",
                    Site = "https://rustserver3.com"
                }
            },
            new Server
            {
                Hostname = "Rust Battle Server #4",
                Map = "Battle Royale Map",
                Players = 95,
                MaxPlayers = 120,
                Tags = "Battle Royale, PVP, Fast Paced",
                Ip = "192.168.1.103",
                Port = 28021,
                QueryPort = 28022,
                Description = "Сервер для быстрых сражений в стиле battle royale",
                HeaderImage = "https://example.com/server4.jpg",
                Status = "premium",
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver4",
                    Discord = "https://discord.gg/rustserver4",
                    Telegram = "https://t.me/rustserver4",
                    Steam = "https://steamcommunity.com/groups/rustserver4",
                    Site = "https://rustserver4.com"
                }
            },
            new Server
            {
                Hostname = "Rust Roleplay Server #5",
                Map = "Roleplay Map",
                Players = 75,
                MaxPlayers = 80,
                Tags = "Roleplay, PVE, Story",
                Ip = "192.168.1.104",
                Port = 28023,
                QueryPort = 28024,
                Description = "Сервер для ролевых игр с развитой экономикой",
                HeaderImage = "https://example.com/server5.jpg",
                Status = "vip",
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver5",
                    Discord = "https://discord.gg/rustserver5",
                    Telegram = "https://t.me/rustserver5",
                    Steam = "https://steamcommunity.com/groups/rustserver5",
                    Site = "https://rustserver5.com"
                }
            },
            new Server
            {
                Hostname = "Rust Hardcore Server #6",
                Map = "Hardcore Map",
                Players = 60,
                MaxPlayers = 75,
                Tags = "Hardcore, PVP, No Rules",
                Ip = "192.168.1.105",
                Port = 28025,
                QueryPort = 28026,
                Description = "Хардкорный сервер без правил для опытных игроков",
                HeaderImage = "https://example.com/server6.jpg",
                Status = "regular",
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver6",
                    Discord = "https://discord.gg/rustserver6",
                    Telegram = "https://t.me/rustserver6",
                    Steam = "https://steamcommunity.com/groups/rustserver6",
                    Site = "https://rustserver6.com"
                }
            },
            new Server
            {
                Hostname = "Rust Tournament Server #7",
                Map = "Tournament Map",
                Players = 110,
                MaxPlayers = 150,
                Tags = "Tournament, PVP, Competitive",
                Ip = "192.168.1.106",
                Port = 28027,
                QueryPort = 28028,
                Description = "Сервер для турниров и соревнований",
                HeaderImage = "https://example.com/server7.jpg",
                Status = "premium",
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver7",
                    Discord = "https://discord.gg/rustserver7",
                    Telegram = "https://t.me/rustserver7",
                    Steam = "https://steamcommunity.com/groups/rustserver7",
                    Site = "https://rustserver7.com"
                }
            },
            new Server
            {
                Hostname = "Rust Beginner Server #8",
                Map = "Beginner Map",
                Players = 25,
                MaxPlayers = 50,
                Tags = "Beginner, PVE, Learning",
                Ip = "192.168.1.107",
                Port = 28029,
                QueryPort = 28030,
                Description = "Сервер для новичков с обучением и помощью",
                HeaderImage = "https://example.com/server8.jpg",
                Status = "regular",
                Urls = new ServerUrl
                {
                    VK = "https://vk.com/rustserver8",
                    Discord = "https://discord.gg/rustserver8",
                    Telegram = "https://t.me/rustserver8",
                    Steam = "https://steamcommunity.com/groups/rustserver8",
                    Site = "https://rustserver8.com"
                }
            }
        };

        await _context.Servers.AddRangeAsync(servers);

        // Создаем хостинги
        var hostings = new List<Hosting>
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
            },
            new Hosting
            {
                Name = "Budget Hosting",
                Description = "Бюджетный хостинг для небольших проектов",
                Image = "https://example.com/budget-hosting.jpg",
                Users = 300,
                Projects = 10,
                Url = "https://budget-hosting.com",
                Status = 1 // Reliable
            },
            new Hosting
            {
                Name = "Enterprise Hosting",
                Description = "Корпоративный хостинг для крупных проектов",
                Image = "https://example.com/enterprise-hosting.jpg",
                Users = 2500,
                Projects = 100,
                Url = "https://enterprise-hosting.com",
                Status = 0 // OurChoice
            }
        };

        await _context.Hostings.AddRangeAsync(hostings);

        // Создаем новости
        var news = new List<NewsItem>
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
            },
            new NewsItem
            {
                Title = "Новые карты доступны",
                Description = "Добавлены новые карты для всех типов серверов",
                Image = "https://example.com/news4.jpg",
                DateCreate = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd")
            },
            new NewsItem
            {
                Title = "Система достижений",
                Description = "Внедрена новая система достижений для игроков",
                Image = "https://example.com/news5.jpg",
                DateCreate = DateTime.Now.AddDays(-12).ToString("yyyy-MM-dd")
            },
            new NewsItem
            {
                Title = "Обновление анти-чита",
                Description = "Улучшена система защиты от читеров",
                Image = "https://example.com/news6.jpg",
                DateCreate = DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd")
            }
        };

        await _context.NewsItems.AddRangeAsync(news);

        // Создаем статистику
        var statistics = new StatisticsData
        {
            UsersOnline = 1250,
            ServersCount = servers.Count
        };

        await _context.StatisticsData.AddAsync(statistics);

        // Создаем информацию о версиях
        var versionInfo = new VersionInfo
        {
            CurrentVersion = "2.1.0",
            Clients = new Dictionary<string, string>
            {
                { "actual", "2.1.0" },
                { "333", "1.9.5" },
                { "12333", "1.8.2" },
                { "beta", "2.2.0-beta" },
                { "alpha", "2.3.0-alpha" }
            },
            SFTP = new List<SftpInfo>
            {
                new SftpInfo
                {
                    Host = "sftp.hoster.by",
                    Port = 22,
                    User = "user2120",
                    Pass = "uT3cB1xE1r"
                },
                new SftpInfo
                {
                    Host = "sftp.backup.hoster.by",
                    Port = 22,
                    User = "backup_user",
                    Pass = "backup_pass_123"
                }
            }
        };

        await _context.VersionInfos.AddAsync(versionInfo);

        // Сохраняем все изменения
        await _context.SaveChangesAsync();
    }
} 