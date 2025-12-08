namespace Application.Features.Opinions.Dtos;

public record OpinionsFilter(
    string? Name,
    string? Role,
    int? Rating,
    string? Content
    );