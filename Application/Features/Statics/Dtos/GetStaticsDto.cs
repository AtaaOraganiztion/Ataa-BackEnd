namespace Application.Features.Statics.Dtos;

public record GetStaticsDto(
    Ulid? Id,
    Ulid? ServiceId,
    int? Number,
    string? Title
    );