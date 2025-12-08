namespace Application.Features.News.Dtos;

public record GetServicesDto(
    Ulid? Id,
    string? Title,
    string? ShortDesc, 
    string? LongDesc
    );