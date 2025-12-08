using Domain.Models.News.Entities;

namespace Application.Features.Services.Dtos;

public record UpdateServicesDto(
    string? Title,
    string? ShortDesc, 
    string? LongDesc,
    string? ImageUrl
    );