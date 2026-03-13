using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Persistence.Models;

namespace WebApi.Persistence.Database.Configuration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(a => a.Id);
        

        builder
            .HasMany(a => a.Lyrics)
            .WithOne(l => l.Album)
            .HasForeignKey(l => l.AlbumId);
    }
}