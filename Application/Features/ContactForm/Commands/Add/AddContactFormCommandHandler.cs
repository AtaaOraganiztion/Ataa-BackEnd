using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Services.Commands.Add;
using AutoMapper;
using SharedKernel;

namespace Application.Features.ContactForm.Commands.Add;

public class AddContactFormCommandHandler(IMapper mapper, IRepository<Domain.Models.ContactForm.Entities.ContactForm> repository) : ICommandHandler<AddContactFormCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddContactFormCommand request, CancellationToken cancellationToken)
    {
        var contactForm = mapper.Map<Domain.Models.ContactForm.Entities.ContactForm>(request);

        await repository.AddAsync(contactForm, cancellationToken);
        return Result.Success(contactForm.Id);
    }
}