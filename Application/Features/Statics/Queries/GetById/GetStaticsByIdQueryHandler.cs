using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Statics.Dtos;
using Application.Features.Statics.Specifications;
using AutoMapper;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Statics.Queries.GetById;

public class GetStaticsByIdQueryHandler(IRepository<Domain.Models.Services.Entities.Statics> repository, IMapper mapper) : IQueryHandler<GetStaticsByIdQuery, GetStaticsDto>
{
    public async Task<Result<GetStaticsDto>> Handle(GetStaticsByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Services.Entities.Statics? statics = await repository.FirstOrDefaultAsync(new StaticsByIdSpec(request.Id), cancellationToken);
        if (statics is null)
        {
            return Result.Failure<GetStaticsDto>(Error.NotFound(ServicesMessageKeys.StaticsNotFound));
        }
        GetStaticsDto staticsDto = mapper.Map<GetStaticsDto>(statics);
        return Result.Success(staticsDto);
    }
}