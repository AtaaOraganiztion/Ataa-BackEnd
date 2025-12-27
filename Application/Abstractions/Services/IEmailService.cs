using Application.Features.ContactForm.Commands.Add;
using Application.Features.ContactForm.Dtos;
using Domain.Email;
using Domain.Models.ContactForm.Enums;

namespace Application.Abstractions.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailModel emailModel, EmailSubject subject, HtmlTemplate htmlTemplate);
    Task SendEmailForm(EmailModel emailModel, string subject, HtmlTemplate htmlTemplate);

}
