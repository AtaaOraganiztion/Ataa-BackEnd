namespace Application.Features.Opinions.Dtos;

public record GetOpinionsDto(
    Ulid Id,
    string? Name,
    string? Role,
    int? Rating,
    string? Content,
    string? AvatarKey
    );