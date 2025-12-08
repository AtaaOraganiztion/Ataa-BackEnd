using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Features.Dtos;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Features.Queries.GetAll;

public class GetFeaturesQueryHandler(IRepository<Domain.Models.Services.Entities.Features> repository, IMapper mapper) : IQueryHandler<GetFeaturesQuery, List<GetFeaturesDto>>
{
    public async Task<Result<List<GetFeaturesDto>>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Services.Entities.Features> featuresList = await repository.ListAsync(
            new GetFeaturesSpec(request.FeaturesFilter),
            cancellationToken);
            
        List<GetFeaturesDto> featuresDtos = mapper.Map<List<GetFeaturesDto>>(featuresList);
        return Result.Success(featuresDtos);
    }
}