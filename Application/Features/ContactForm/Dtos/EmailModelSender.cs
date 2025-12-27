using Domain.Email;
using Domain.Models.ContactForm.Enums;

namespace Application.Features.ContactForm.Dtos;

public record EmailModelSender(
    string Name,
    String EntityName,
    string Email,
    string Phone,
    RequestType RequestType,
    string Message,
    String ToEmailAddress
    
    ): EmailModel(Name, ToEmailAddress, HtmlTemplate.Form);