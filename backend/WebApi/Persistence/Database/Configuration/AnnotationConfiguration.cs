using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Annotation = WebApi.Persistence.Models.Annotation;

namespace WebApi.Persistence.Database.Configuration;

public class AnnotationConfiguration : IEntityTypeConfiguration<Annotation>
{
    public void Configure(EntityTypeBuilder<Annotation> builder)
    {
        builder.HasKey(a => a.Id);

    }
}