using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Services.Specifications;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Services.Commands.Delete;

public class DeleteServicesCommandHandler(IRepository<Domain.Models.Services.Entities.Services> repository) : ICommandHandler<DeleteServicesCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteServicesCommand request, CancellationToken cancellationToken)
    {
        var services = await repository.FirstOrDefaultAsync(new ServicesByIdSpec(request.Id),cancellationToken);
        if (services is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ServicesMessageKeys.ServicesNotFound));
        }

        await repository.DeleteAsync(services, cancellationToken);
        return Result.Success(services.Id);
    }
}