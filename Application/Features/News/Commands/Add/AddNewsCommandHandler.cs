using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using SharedKernel;

namespace Application.Features.News.Commands.Add;

public class AddNewsCommandHandler(IMapper mapper, IRepository<Domain.Models.News.Entities.News> repository) : ICommandHandler<AddNewsCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddNewsCommand request, CancellationToken cancellationToken)
    {
        var news = mapper.Map<Domain.Models.News.Entities.News>(request);

        await repository.AddAsync(news, cancellationToken);
        return Result.Success(news.Id);
    }
}