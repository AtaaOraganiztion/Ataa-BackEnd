using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.Statics.Queries.GetById;

public record GetStaticsByIdQuery(Ulid Id) : IQuery<GetStaticsDto>;