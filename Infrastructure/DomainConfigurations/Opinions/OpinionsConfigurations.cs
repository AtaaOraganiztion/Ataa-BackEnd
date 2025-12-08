using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Opinions;

public class OpinionsConfigurations : IEntityTypeConfiguration<Domain.Models.Opinions.Entities.Opinions>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Opinions.Entities.Opinions> builder)
    {
        builder.ToTable("Opinions");
        builder
            .HasIndex(b => b.Name);
        builder
            .HasIndex(b => b.Rating);   
        builder
            .HasIndex(b=> b.Role);
        
    }
}