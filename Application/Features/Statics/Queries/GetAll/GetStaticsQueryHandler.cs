using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Features.Dtos;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.Statics.Dtos;
using Application.Features.Statics.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Statics.Queries.GetAll;

public class GetStaticsQueryHandler(IRepository<Domain.Models.Services.Entities.Statics> repository, IMapper mapper) : IQueryHandler<GetStaticsQuery, List<GetStaticsDto>>
{
    public async Task<Result<List<GetStaticsDto>>> Handle(GetStaticsQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Services.Entities.Statics> staticsList = await repository.ListAsync(
            new GetStaticsSpec(request.StaticsFilter),
            cancellationToken);
            
        List<GetStaticsDto> staticsDtos = mapper.Map<List<GetStaticsDto>>(staticsList);
        return Result.Success(staticsDtos);
    }
}