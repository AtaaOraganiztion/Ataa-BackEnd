using SharedKernel;

namespace Domain.Models.Opinions.Entities;

public class Opinions : Entity,IAuditableEntity,ISoftDeletableEntity
{
    
    public string Name { get; set; }
    public string AvatarKey { get; set; }  
    public string Role { get; set; }
    public int Rating { get; set; } // 1–5
    public string Content { get; set; }
    
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}