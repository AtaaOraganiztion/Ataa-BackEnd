namespace Application.Features.Features.Dtos;

public record GetFeaturesDto(
    Ulid? Id,
    Ulid? ServiceId,
    string? Title,
    string? Desc, 
    string? Benifit
    );