using SharedKernel;

namespace Domain.Models.Services.Entities;

public class Gallery : Entity,IAuditableEntity,ISoftDeletableEntity
    
{
    public Ulid ServiceId { get; set; }
    public Services Services { get; set; }
    public string ImageUrl { get; set; }   
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}