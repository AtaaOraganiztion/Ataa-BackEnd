using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.News.Queries.GetAll;

public class GetNewsQueryHandler(IRepository<Domain.Models.News.Entities.News> repository, IMapper mapper) : IQueryHandler<GetNewsQuery, List<GetNewsDto>>
{
    public async Task<Result<List<GetNewsDto>>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.News.Entities.News> news = await repository.ListAsync(
            new GetNewsSpec(request.NewsFilter),
            cancellationToken);
            
        List<GetNewsDto> newsDtos = mapper.Map<List<GetNewsDto>>(news);
        return Result.Success(newsDtos);
    }
}