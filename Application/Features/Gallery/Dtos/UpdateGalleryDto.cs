using Microsoft.AspNetCore.Http;

namespace Application.Features.Gallery.Dtos;

public record UpdateGalleryDto(string? ImageUrl, IFormFile? ImageFile);