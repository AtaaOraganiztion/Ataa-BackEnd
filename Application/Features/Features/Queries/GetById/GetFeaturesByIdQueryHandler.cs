using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Features.Dtos;
using Application.Features.Features.Specifications;
using AutoMapper;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Features.Queries.GetById;

public class GetFeaturesByIdQueryHandler(IRepository<Domain.Models.Services.Entities.Features> repository, IMapper mapper) : IQueryHandler<GetFeaturesByIdQuery, GetFeaturesDto>
{
    public async Task<Result<GetFeaturesDto>> Handle(GetFeaturesByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Services.Entities.Features? features = await repository.FirstOrDefaultAsync(new FeaturesByIdSpec(request.Id), cancellationToken);
        if (features is null)
        {
            return Result.Failure<GetFeaturesDto>(Error.NotFound(ServicesMessageKeys.FeaturesNotFound));
        }
        GetFeaturesDto featuresDto = mapper.Map<GetFeaturesDto>(features);
        return Result.Success(featuresDto);
    }
}