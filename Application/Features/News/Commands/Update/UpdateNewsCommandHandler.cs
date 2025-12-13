using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using SharedKernel;

namespace Application.Features.News.Commands.Update;

public class UpdateNewsCommandHandler(IMapper mapper, IRepository<Domain.Models.News.Entities.News> repository) : ICommandHandler<UpdateNewsCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await repository.FirstOrDefaultAsync(new NewsByIdSpec(request.Id), cancellationToken);
        if (news is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(NewsMessageKeys.NewsNotFound));
        }
        var updatedNews = mapper.Map(request.NewsDto, news);
        await repository.UpdateAsync(updatedNews, cancellationToken);
        return Result.Success(updatedNews.Id);
    }
}