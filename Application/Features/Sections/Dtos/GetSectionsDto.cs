namespace Application.Features.Sections.Dtos;

public record GetSectionsDto(Ulid? Id, Ulid? NewsId, string? Heading, string? Content);