using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using urlShortener.Models;

namespace urlShortener.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UrlMapping> url_mappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UrlMapping>().HasKey(u => new { u.ShortenedUrl });
    }
}