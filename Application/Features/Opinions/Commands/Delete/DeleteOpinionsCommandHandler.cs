using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.Opinions.Specifications;
using Domain.Models.News;
using Domain.Models.Opinions;
using SharedKernel;

namespace Application.Features.Opinions.Commands.Delete;

public class DeleteOpinionsCommandHandler(IRepository<Domain.Models.Opinions.Entities.Opinions> repository) : ICommandHandler<DeleteOpinionsCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteOpinionsCommand request, CancellationToken cancellationToken)
    {
        var opinions = await repository.FirstOrDefaultAsync(new OpinionsByIdSpec(request.Id),cancellationToken);
        if (opinions is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(OpinionsMessageKeys.OpinionsNotFound));
        }

        await repository.DeleteAsync(opinions, cancellationToken);
        return Result.Success(opinions.Id);
    }
}