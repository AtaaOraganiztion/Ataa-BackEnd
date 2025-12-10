namespace Application.Features.Gallery.Dtos;

public record GalleryFilter(
    Ulid? ServiceId,
    string? ImageUrl
    );