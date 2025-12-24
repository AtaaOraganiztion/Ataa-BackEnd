using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.ContactForm.Dtos;
using Application.Features.ContactForm.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.ContactForm;
using SharedKernel;

namespace Application.Features.ContactForm.Queries.GetById;

public class GetContactFormByIdQueryHandler(IRepository<Domain.Models.ContactForm.Entities.ContactForm> repository, IMapper mapper) : IQueryHandler<GetContactFormByIdQuery, GetContactFormDto>
{
    public async Task<Result<GetContactFormDto>> Handle(GetContactFormByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.ContactForm.Entities.ContactForm? contactForm = await repository.FirstOrDefaultAsync(new ContactFormByIdSpec(request.Id), cancellationToken);
        if (contactForm is null)
        {
            return Result.Failure<GetContactFormDto>(Error.NotFound(ContactFormMessageKeys.ContactFormNotFound));
        }
        GetContactFormDto contactFormDto = mapper.Map<GetContactFormDto>(contactForm);
        return Result.Success(contactFormDto);
    }
}