using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using urlShortener.Models;

namespace urlShortener.Data;

public class AppDbContext: DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public DbSet<UrlMapping> url_mappings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("SupabaseDB"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UrlMapping>().HasKey(u => new { u.ShortenedUrl });
    }
}