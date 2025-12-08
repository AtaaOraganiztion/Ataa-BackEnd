using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.Statics.Specifications;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Statics.Commands.Delete;

public class DeleteStaticsCommandHandler(IRepository<Domain.Models.Services.Entities.Statics> repository) : ICommandHandler<DeleteStaticsCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteStaticsCommand request, CancellationToken cancellationToken)
    {
        var statics = await repository.FirstOrDefaultAsync(new StaticsByIdSpec(request.Id),cancellationToken);
        if (statics is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ServicesMessageKeys.StaticsNotFound));
        }

        await repository.DeleteAsync(statics, cancellationToken);
        return Result.Success(statics.Id);
    }
}