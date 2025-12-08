namespace Application.Features.Opinions.Dtos;

public record GetOpinionsDto(
    string? Name,
    string? Role,
    int? Rating,
    string? Content,
    string? AvatarKey
    );