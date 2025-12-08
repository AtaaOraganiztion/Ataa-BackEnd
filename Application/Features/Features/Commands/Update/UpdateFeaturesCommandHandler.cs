using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using SharedKernel;

namespace Application.Features.Features.Commands.Update;

public class UpdateFeaturesCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Features> repository) : ICommandHandler<UpdateFeaturesCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateFeaturesCommand request, CancellationToken cancellationToken)
    {
        var features = await repository.FirstOrDefaultAsync(new FeaturesByIdSpec(request.Id), cancellationToken);
        if (features is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ServicesMessageKeys.FeaturesNotFound));
        }
        var updatedFeatures = mapper.Map(request.FeaturesDto, features);
        await repository.UpdateAsync(updatedFeatures, cancellationToken);
        return Result.Success(updatedFeatures.Id);
    }
}