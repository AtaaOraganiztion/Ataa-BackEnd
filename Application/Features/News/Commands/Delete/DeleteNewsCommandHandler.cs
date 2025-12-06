using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.News.Commands.Delete;

public class DeleteNewsCommandHandler(IRepository<Domain.Models.News.Entities.News> repository) : ICommandHandler<DeleteNewsCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await repository.FirstOrDefaultAsync(new NewsByIdSpec(request.Id),cancellationToken);
        if (news is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(NewsMessageKeys.NewsNotFound));
        }

        await repository.DeleteAsync(news, cancellationToken);
        return Result.Success(news.Id);
    }
}