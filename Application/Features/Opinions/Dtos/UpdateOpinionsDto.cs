using Domain.Models.News.Entities;

namespace Application.Features.Opinions.Dtos;

public record UpdateOpinionsDto(
    string? Name,
    string? Role,
    int? Rating,
    string? Content,
    string? AvatarKey
    );