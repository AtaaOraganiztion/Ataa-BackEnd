using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;

namespace Application.Features.News.Queries.GetById;

public record GetNewsByIdQuery(Ulid Id) : IQuery<GetNewsDto>;