using Application.Abstractions.Messaging;
using Application.Features.Sections.Dtos;

namespace Application.Features.Sections.Queries.GetById;

public record GetSectionsByIdQuery(Ulid Id) : IQuery<GetSectionsDto>;