using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Persistence.Models;

namespace WebApi.Persistence.Database.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder
            .HasIndex(u => u.Login)
            .IsUnique();
        
        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(r => r.RoleId);

        builder
            .HasMany(u => u.Albums)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        builder
            .HasMany(u => u.Annotations)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);
    }
}