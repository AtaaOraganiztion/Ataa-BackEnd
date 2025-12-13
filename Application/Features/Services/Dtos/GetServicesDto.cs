namespace Application.Features.Services.Dtos;

public record GetServicesDto(
    Ulid? Id,
    string? Title,
    string? ShortDesc,
    string? LongDesc,
    string? MainImage
    );