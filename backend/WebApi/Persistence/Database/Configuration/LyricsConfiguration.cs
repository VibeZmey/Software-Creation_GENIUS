using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Persistence.Models;

namespace WebApi.Persistence.Database.Configuration;

public class LyricsConfiguration : IEntityTypeConfiguration<Lyrics>
{
    public void Configure(EntityTypeBuilder<Lyrics> builder)
    {
        builder.HasKey(l => l.Id);
        
        builder
            .HasMany(l => l.Annotations)
            .WithOne(a => a.Lyrics)
            .HasForeignKey(l => l.LyricsId);
        
    }
}