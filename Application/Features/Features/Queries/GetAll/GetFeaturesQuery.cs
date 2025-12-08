using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;

namespace Application.Features.Features.Queries.GetAll;

public record GetFeaturesQuery(FeaturesFilter FeaturesFilter) : IQuery<List<GetFeaturesDto>>;