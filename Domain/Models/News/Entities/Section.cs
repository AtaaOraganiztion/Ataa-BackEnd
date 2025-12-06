using SharedKernel;

namespace Domain.Models.News.Entities;

public class Section : Entity,IAuditableEntity,ISoftDeletableEntity
{
    public Ulid NewsId { get; set; }
    public string Heading { get; set; } = null!;
    public string Content { get; set; } = null!;
    public News News { get; set; } = null!;
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}