using Domain.Models.ContactForm.Enums;
using SharedKernel;

namespace Domain.Models.ContactForm.Entities;

public class ContactForm : Entity,IAuditableEntity,ISoftDeletableEntity
{
    
    public string Name {get; set;}
    public string EntityName {get; set;}
    public string Email {get; set;}
    public string Phone {get; set;}
    public RequestType RequestType {get; set;}
    public string Message {get; set;}
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}