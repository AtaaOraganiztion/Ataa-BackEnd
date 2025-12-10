using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Sections.Dtos;
using Application.Features.Sections.Specifications;
using AutoMapper;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Sections.Queries.GetById;

public class GetSectionsByIdQueryHandler(IRepository<Domain.Models.News.Entities.Section> repository, IMapper mapper) : IQueryHandler<GetSectionsByIdQuery, GetSectionsDto>
{
    public async Task<Result<GetSectionsDto>> Handle(GetSectionsByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.News.Entities.Section? section = await repository.FirstOrDefaultAsync(new SectionByIdSpec(request.Id), cancellationToken);
        if (section is null)
        {
            return Result.Failure<GetSectionsDto>(Error.NotFound(NewsMessageKeys.SectionNotFound));
        }
        GetSectionsDto sectionsDto = mapper.Map<GetSectionsDto>(section);
        return Result.Success(sectionsDto);
    }
}