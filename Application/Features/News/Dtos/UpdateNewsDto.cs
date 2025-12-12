using Domain.Models.News.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Features.News.Dtos;

public record UpdateNewsDto(
    string? Title,
    string? Description,
    string? Category,
    string ? Content,
    string? ImageUrl,
    IFormFile? ImageFile,
    string? Qoute
    );