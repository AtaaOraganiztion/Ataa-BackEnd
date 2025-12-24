using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.ContactForm.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using Domain.Models.ContactForm;
using SharedKernel;

namespace Application.Features.ContactForm.Commands.Update;

public class UpdateContactFormCommandHandler(IMapper mapper, IRepository<Domain.Models.ContactForm.Entities.ContactForm> repository) : ICommandHandler<UpdateContactFormCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateContactFormCommand request, CancellationToken cancellationToken)
    {
        var contactForm = await repository.FirstOrDefaultAsync(new ContactFormByIdSpec(request.Id), cancellationToken);
        if (contactForm is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ContactFormMessageKeys.ContactFormNotFound));
        }
        var updatedContactForm = mapper.Map(request.ContactFormDto, contactForm);
        await repository.UpdateAsync(updatedContactForm, cancellationToken);
        return Result.Success(updatedContactForm.Id);
    }
}