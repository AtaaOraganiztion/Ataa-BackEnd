namespace Application.Features.Statics.Dtos;

public record GetStaticsDto(
    Ulid? Id,
    int? Number,
    string? Title
    );