using Domain.Models.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Services;

public class GalleryConfigurations : IEntityTypeConfiguration<Gallery>
{
    public void Configure(EntityTypeBuilder<Gallery> builder)
    {
        builder.ToTable("Gallery");
        builder
            .HasIndex(b => b.ImageUrl);

    }
}