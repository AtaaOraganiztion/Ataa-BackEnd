using Application.Abstractions.Messaging;
using Application.Features.Features.Dtos;
using Application.Features.Opinions.Dtos;
using Application.Features.Sections.Dtos;

namespace Application.Features.Features.Queries.GetById;

public record GetFeaturesByIdQuery(Ulid Id) : IQuery<GetFeaturesDto>;