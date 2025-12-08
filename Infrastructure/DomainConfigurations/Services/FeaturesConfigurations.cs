using Domain.Models.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Services;

public class FeaturesConfigurations : IEntityTypeConfiguration<Features>
{
    public void Configure(EntityTypeBuilder<Features> builder)
    {
        builder.ToTable("Features");
        builder
            .HasIndex(b => b.Title);
        builder
            .HasIndex(x => x.Benifit);
    }
}