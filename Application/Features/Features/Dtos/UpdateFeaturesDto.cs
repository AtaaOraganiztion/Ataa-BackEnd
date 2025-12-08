using Domain.Models.News.Entities;

namespace Application.Features.Services.Dtos;

public record UpdateFeaturesDto(
    string? Title,
    string? Desc, 
    string? Benifit
    );