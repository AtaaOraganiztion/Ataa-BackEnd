namespace Application.Features.News.Dtos;

public record GetNewsDto(
    Ulid? Id = null,
    string? Title = null,
    string? Description = null,
    string? Category = null,
    string? Content = null,
    string? ImageUrl = null,
    string? Qoute = null,
    DateTime? PublishedOnUtc = null
);
