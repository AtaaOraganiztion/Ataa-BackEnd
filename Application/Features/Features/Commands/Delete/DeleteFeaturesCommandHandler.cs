using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Features.Commands.Delete;

public class DeleteFeaturesCommandHandler(IRepository<Domain.Models.Services.Entities.Features> repository) : ICommandHandler<DeleteFeaturesCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteFeaturesCommand request, CancellationToken cancellationToken)
    {
        var features = await repository.FirstOrDefaultAsync(new FeaturesByIdSpec(request.Id),cancellationToken);
        if (features is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ServicesMessageKeys.FeaturesNotFound));
        }

        await repository.DeleteAsync(features, cancellationToken);
        return Result.Success(features.Id);
    }
}