using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.ContactForm.Dtos;
using Application.Features.ContactForm.Specifications;
using Application.Features.Features.Dtos;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.Opinions.Dtos;
using Application.Features.Opinions.Specifications;
using Application.Features.Statics.Dtos;
using Application.Features.Statics.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.ContactForm.Queries.GetAll;

public class GetContactFormQueryHandler(IRepository<Domain.Models.ContactForm.Entities.ContactForm> repository, IMapper mapper) : IQueryHandler<GetContactFormQuery, List<GetContactFormDto>>
{
    public async Task<Result<List<GetContactFormDto>>> Handle(GetContactFormQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.ContactForm.Entities.ContactForm> contactForms = await repository.ListAsync(
            new GetContactFormSpec(request.ContactFormFilter),
            cancellationToken);
            
        List<GetContactFormDto> contactFormDtos = mapper.Map<List<GetContactFormDto>>(contactForms);
        return Result.Success(contactFormDtos);
    }
}