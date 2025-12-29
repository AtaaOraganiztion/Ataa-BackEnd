using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Features.ContactForm.Dtos;
using Application.Features.Services.Commands.Add;
using AutoMapper;
using Domain.Email;
using Domain.Models.ContactForm.Enums;
using SharedKernel;

namespace Application.Features.ContactForm.Commands.Add;

public class AddContactFormCommandHandler(IMapper mapper, IRepository<Domain.Models.ContactForm.Entities.ContactForm> repository, IEmailService emailService) : ICommandHandler<AddContactFormCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddContactFormCommand request, CancellationToken cancellationToken)
    {
        var contactForm = mapper.Map<Domain.Models.ContactForm.Entities.ContactForm>(request);
        await repository.AddAsync(contactForm, cancellationToken);
        
        var emailModel = new EmailModelSender(
            Name: request.Name,
            Email: request.Email,
            Message: request.Message,
            RequestType:request.RequestType,
            Phone: request.Phone,
            EntityName:request.EntityName,
            ToEmailAddress: "Info@alataa.sa"
            
        );
        var requestTypeArabic = request.RequestType.GetDescription();

        await emailService.SendEmailForm(emailModel, requestTypeArabic, HtmlTemplate.Form);
        
        return Result.Success(contactForm.Id);
    }
}