using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.ContactForm;

public class ContactFormConfigurations : IEntityTypeConfiguration<Domain.Models.ContactForm.Entities.ContactForm>
{
    public void Configure(EntityTypeBuilder<Domain.Models.ContactForm.Entities.ContactForm> builder)
    {
        builder.ToTable("ContactForm");
        builder
            .HasIndex(b => b.Name);
        builder
            .HasIndex(b => b.Email);   
        builder
            .HasIndex(b=> b.Phone);
        builder
            .HasIndex(b=> b.EntityName);
        builder
            .HasIndex(b=> b.RequestType);
    }
}