using Domain.Models.News.Entities;

namespace Application.Features.News.Dtos;

public record UpdateNewsDto(
    string? Title,
    string? Description,
    string? Category,
    string ? Content,
    string? ImageUrl,
    string? Qoute
    );