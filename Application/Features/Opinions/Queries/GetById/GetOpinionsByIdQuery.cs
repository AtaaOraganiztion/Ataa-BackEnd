using Application.Abstractions.Messaging;
using Application.Features.Opinions.Dtos;
using Application.Features.Sections.Dtos;

namespace Application.Features.Opinions.Queries.GetById;

public record GetOpinionsByIdQuery(Ulid Id) : IQuery<GetOpinionsDto>;