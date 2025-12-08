using SharedKernel;

namespace Domain.Models.Services.Entities;

public class Statics : Entity,IAuditableEntity,ISoftDeletableEntity
{
    public string Title { get; set; }
    public int Number { get; set; }

    public Ulid ServiceId { get; set; }
    public Services Services { get; set; }
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}