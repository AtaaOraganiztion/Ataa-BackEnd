using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using AutoMapper;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.News.Queries.GetById;

public class GetNewsByIdQueryHandler(IRepository<Domain.Models.News.Entities.News> repository, IMapper mapper) : IQueryHandler<GetNewsByIdQuery, GetNewsDto>
{
    public async Task<Result<GetNewsDto>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.News.Entities.News? news = await repository.FirstOrDefaultAsync(new NewsByIdSpec(request.Id), cancellationToken);
        if (news is null)
        {
            return Result.Failure<GetNewsDto>(Error.NotFound(NewsMessageKeys.NewsNotFound));
        }
        GetNewsDto newsDto = mapper.Map<GetNewsDto>(news);
        return Result.Success(newsDto);
    }
}