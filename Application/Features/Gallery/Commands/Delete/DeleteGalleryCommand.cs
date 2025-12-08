using Application.Abstractions.Messaging;

namespace Application.Features.Gallery.Commands.Delete;

public record DeleteGalleryCommand(Ulid Id) : ICommand<Ulid>;