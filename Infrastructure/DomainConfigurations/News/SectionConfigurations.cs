using Domain.Models.News.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.News;

public class SectionConfigurations : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");
        builder
            .HasIndex(b => b.Heading);
        builder
            .HasIndex(b => b.Content);
        
    }
}