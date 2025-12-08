using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel;

namespace Domain.Models.Services.Entities;

public class Services : Entity,IAuditableEntity,ISoftDeletableEntity
{
    public string Title { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public string? MainImage { get; set; }

    public List<Statics> Statics { get; set; }
    public List<Gallery> GalleryImages { get; set; }
    public List<Features> Features { get; set; }
    
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}