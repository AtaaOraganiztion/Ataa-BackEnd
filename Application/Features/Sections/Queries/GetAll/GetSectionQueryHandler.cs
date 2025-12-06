using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using Application.Features.Sections.Dtos;
using Application.Features.Sections.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Sections.Queries.GetAll;

public class GetSectionQueryHandler(IRepository<Domain.Models.News.Entities.Section> repository, IMapper mapper) : IQueryHandler<GetSectionQuery, List<GetSectionsDto>>
{
    public async Task<Result<List<GetSectionsDto>>> Handle(GetSectionQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.News.Entities.Section> sections = await repository.ListAsync(
            new GetSectionSpec(request.SectionsFilter),
            cancellationToken);
            
        List<GetSectionsDto> sectionsDtos = mapper.Map<List<GetSectionsDto>>(sections);
        return Result.Success(sectionsDtos);
    }
}