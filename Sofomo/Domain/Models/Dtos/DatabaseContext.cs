using Microsoft.EntityFrameworkCore;
using Sofomo.Domain.Models.Dtos;

public class DatabaseContext : DbContext
{
    public DbSet<LocationDto> Locations { get; set; }
    public DbSet<WeatherDto> Weather { get; set; }
    public string DbPath { get; }

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "WeatherForecast.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
