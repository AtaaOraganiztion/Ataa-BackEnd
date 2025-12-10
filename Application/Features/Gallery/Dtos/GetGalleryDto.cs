namespace Application.Features.Gallery.Dtos;

public record GetGalleryDto(
    Ulid? Id,
    Ulid? ServiceId,
    string? ImageUrl
    );