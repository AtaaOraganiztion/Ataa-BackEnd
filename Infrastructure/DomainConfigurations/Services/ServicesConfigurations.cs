using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Services;

public class ServicesConfigurations : IEntityTypeConfiguration<Domain.Models.Services.Entities.Services>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Services.Entities.Services> builder)
    {
        builder.ToTable("Services");
        builder
            .HasIndex(b => b.Title);
        builder
            .HasIndex(x => x.ShortDesc);

        
        builder.HasMany(n => n.Statics)
            .WithOne(x=> x.Services) 
            .HasForeignKey(s => s.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(n => n.GalleryImages)
            .WithOne(x=> x.Services) 
            .HasForeignKey(s => s.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(n => n.Features)
            .WithOne(x=> x.Services) 
            .HasForeignKey(s => s.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}