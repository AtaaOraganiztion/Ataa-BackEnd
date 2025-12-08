namespace Application.Features.Features.Dtos;

public record GetFeaturesDto(
    Ulid? Id,
    string? Title,
    string? Desc, 
    string? Benifit
    );