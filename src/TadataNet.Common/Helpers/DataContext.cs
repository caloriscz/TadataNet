using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using TadataNet.Common.Entities;

namespace TadataNet.Common.Helpers;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<LinkTag> LinkTags { get; set; }
    public DbSet<UserSetting> UserSettings { get; set; }
    public DbSet<Param> Params { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Url> Urls { get; set; }
    public DbSet<UrlParam> UrlParams { get; set; }

    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        //options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        options.UseSqlServer("server=DESKTOP-GVU5S4G\\CALORISEXPRESS;user=sa;password=7Aqua.Kid;database=tadatacz");
        options.EnableSensitiveDataLogging();
    }
}
