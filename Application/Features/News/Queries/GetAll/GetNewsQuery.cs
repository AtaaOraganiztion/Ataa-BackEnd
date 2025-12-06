using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;

namespace Application.Features.News.Queries.GetAll;

public record GetNewsQuery(NewsFilter NewsFilter) : IQuery<List<GetNewsDto>>;