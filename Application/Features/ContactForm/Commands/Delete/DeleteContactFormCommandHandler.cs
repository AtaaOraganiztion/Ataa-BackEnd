using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.ContactForm.Specifications;
using Domain.Models.ContactForm;
using SharedKernel;

namespace Application.Features.ContactForm.Commands.Delete;

public class DeleteContactFormCommandHandler(IRepository<Domain.Models.ContactForm.Entities.ContactForm> repository) : ICommandHandler<DeleteContactFormCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteContactFormCommand request, CancellationToken cancellationToken)
    {
        var contactForm = await repository.FirstOrDefaultAsync(new ContactFormByIdSpec(request.Id),cancellationToken);
        if (contactForm is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ContactFormMessageKeys.ContactFormNotFound));
        }

        await repository.DeleteAsync(contactForm, cancellationToken);
        return Result.Success(contactForm.Id);
    }
}