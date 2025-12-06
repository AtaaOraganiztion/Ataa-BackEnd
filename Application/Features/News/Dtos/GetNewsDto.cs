namespace Application.Features.News.Dtos;

public record GetNewsDto(
    Ulid? Id,
    string? Title,
    string? Description,
    string? Category,
    string? ImageUrl,
    string? Qoute
    );