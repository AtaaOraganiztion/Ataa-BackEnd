using Domain.Models.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Services;

public class StaticsConfigurations : IEntityTypeConfiguration<Statics>
{
    public void Configure(EntityTypeBuilder<Statics> builder)
    {
        builder.ToTable("Statics");

        builder
            .HasIndex(b => b.Number);
        builder
            .HasIndex(x => x.Title);






    }
}