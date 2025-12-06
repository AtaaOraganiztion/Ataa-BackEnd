namespace Application.Features.Sections.Dtos;

public record SectionsDto(
    Ulid? NewsId,
    string? Heading,
    string? Content
);