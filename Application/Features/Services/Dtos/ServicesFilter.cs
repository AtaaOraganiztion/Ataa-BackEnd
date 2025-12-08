namespace Application.Features.Services.Dtos;

public record ServicesFilter(
    string? Title,
    string? ShortDesc, 
    string? LongDesc
    );