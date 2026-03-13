using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Persistence.Database.Configuration;
using WebApi.Persistence.Models;

namespace WebApi.Persistence.Database;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Album> Albums { get; set; }
    public DbSet<Lyrics> Lyrics { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Annotation> Annotations { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new LyricsConfiguration());
        modelBuilder.ApplyConfiguration(new AnnotationConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}