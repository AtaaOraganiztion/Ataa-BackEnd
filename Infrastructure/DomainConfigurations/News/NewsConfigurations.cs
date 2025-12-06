using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.News;

public class NewsConfigurations : IEntityTypeConfiguration<Domain.Models.News.Entities.News>
{
    public void Configure(EntityTypeBuilder<Domain.Models.News.Entities.News> builder)
    {
        builder.ToTable("News");
        builder
            .HasIndex(b => b.Title);
        builder
            .HasIndex(b => b.Category);
        
        builder
            .HasIndex(b => b.ImageUrl);
        builder
            .HasIndex(b => b.Qoute);
        
        builder.HasMany(n => n.Sections)
            .WithOne(x=> x.News) 
            .HasForeignKey(s => s.NewsId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}