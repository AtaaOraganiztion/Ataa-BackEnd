using Domain.Models.News.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Services.Dtos;

public record UpdateServicesDto(
    string? Title,
    string? ShortDesc, 
    string? LongDesc,
    string? ImageUrl,
    IFormFile? ImageFile
    );