namespace Application.Features.News.Dtos;

public record NewsFilter(
    string? Title,
    string? Description,
    string? Category,
    string ? Content,
    string? ImageUrl,
    string? Qoute,
    DateTime? PublishedOnUtc
    );