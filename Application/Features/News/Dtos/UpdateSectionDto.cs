namespace Application.Features.News.Dtos;

public record UpdateSectionDto(
    Ulid? Id,
    string Heading,
    string Content
);