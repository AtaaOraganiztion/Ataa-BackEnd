using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
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

namespace Application.Features.Opinions.Queries.GetAll;

public class GetOpinionsQueryHandler(IRepository<Domain.Models.Opinions.Entities.Opinions> repository, IMapper mapper) : IQueryHandler<GetOpinionsQuery, List<GetOpinionsDto>>
{
    public async Task<Result<List<GetOpinionsDto>>> Handle(GetOpinionsQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Opinions.Entities.Opinions> opinionsList = await repository.ListAsync(
            new GetOpinionsSpec(request.OpinionsFilter),
            cancellationToken);
            
        List<GetOpinionsDto> opinionsDtos = mapper.Map<List<GetOpinionsDto>>(opinionsList);
        return Result.Success(opinionsDtos);
    }
}