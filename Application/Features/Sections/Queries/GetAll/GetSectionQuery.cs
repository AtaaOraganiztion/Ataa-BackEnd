using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Sections.Dtos;

namespace Application.Features.Sections.Queries.GetAll;

public record GetSectionQuery(SectionsDto SectionsFilter) : IQuery<List<GetSectionsDto>>;