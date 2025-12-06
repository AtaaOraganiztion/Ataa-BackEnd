using SharedKernel;

namespace Domain.Models.News.Entities;

public class News : Entity,IAuditableEntity,ISoftDeletableEntity
{
    
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Qoute { get; set; } = null!;
    public DateTime PublishedOnUtc { get; set; } = DateTime.Now;
    public List<Section> Sections { get; set; } = new();
    
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}