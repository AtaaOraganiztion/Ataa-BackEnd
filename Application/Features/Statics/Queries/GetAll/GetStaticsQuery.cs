using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.Statics.Queries.GetAll;

public record GetStaticsQuery(StaticsFilter StaticsFilter) : IQuery<List<GetStaticsDto>>;