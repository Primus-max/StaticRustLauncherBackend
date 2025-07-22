using Microsoft.EntityFrameworkCore;
using StaticRustLauncherBackend.Models;

namespace StaticRustLauncherBackend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Server> Servers { get; set; }
    public DbSet<ServerUrl> ServerUrls { get; set; }
    public DbSet<Hosting> Hostings { get; set; }
    public DbSet<NewsItem> NewsItems { get; set; }
    public DbSet<StatisticsData> StatisticsData { get; set; }
    public DbSet<VersionInfo> VersionInfos { get; set; }
    public DbSet<SftpInfo> SftpInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Настройка Server
        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Hostname).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Map).HasMaxLength(100);
            entity.Property(e => e.Tags).HasMaxLength(500);
            entity.Property(e => e.Ip).IsRequired().HasMaxLength(45);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.HeaderImage).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
            
            entity.HasOne(e => e.Urls)
                  .WithOne(e => e.Server)
                  .HasForeignKey<ServerUrl>(e => e.ServerId);
        });

        // Настройка ServerUrl
        modelBuilder.Entity<ServerUrl>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.VK).HasMaxLength(200);
            entity.Property(e => e.Discord).HasMaxLength(200);
            entity.Property(e => e.Telegram).HasMaxLength(200);
            entity.Property(e => e.Steam).HasMaxLength(200);
            entity.Property(e => e.Site).HasMaxLength(200);
        });

        // Настройка Hosting
        modelBuilder.Entity<Hosting>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Url).HasMaxLength(200);
        });

        // Настройка NewsItem
        modelBuilder.Entity<NewsItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.DateCreate).IsRequired();
        });

        // Настройка StatisticsData
        modelBuilder.Entity<StatisticsData>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Настройка VersionInfo
        modelBuilder.Entity<VersionInfo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CurrentVersion).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Clients).HasConversion(
                v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
                v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(v, (System.Text.Json.JsonSerializerOptions?)null) ?? new Dictionary<string, string>()
            );
            
            entity.HasMany(e => e.SFTP)
                  .WithOne(e => e.VersionInfo)
                  .HasForeignKey(e => e.VersionInfoId);
        });

        // Настройка SftpInfo
        modelBuilder.Entity<SftpInfo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Host).IsRequired().HasMaxLength(200);
            entity.Property(e => e.User).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Pass).IsRequired().HasMaxLength(100);
        });
    }
} 